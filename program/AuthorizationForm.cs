using DemoRestaurant.Admin;
using DemoRestaurant.Manager;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoRestaurant
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            LoadRemembreUser();
        }

        private void LoadRemembreUser()
        {
            if (Properties.Settings.Default.rememberUser)
            {
                textBox_login.Text = Properties.Settings.Default.remember_login;
                textBox_password.Text = Properties.Settings.Default.remember_password;
                checkBox_remember.Checked = Properties.Settings.Default.rememberUser;
            }
        }

        private void button_log_in_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("MySQL server disconnect");
                }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT COUNT(*) FROM `personnel-authorization` WHERE (password=@password AND login=@login);";
                    query.Parameters.AddWithValue("@password", textBox_password.Text);
                    query.Parameters.AddWithValue("@login", textBox_login.Text);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == 0)
                            {
                                MessageBox.Show("login or password incorrect");
                                return;
                            }
                        }
                    }
                    query.CommandText = "SELECT * FROM `personnel-data` WHERE `id`=(SELECT `personnel-data_id` FROM `personnel-authorization` WHERE (`password` = @password AND `login`=@login));";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            #region remember user
                            if (checkBox_remember.Checked)
                            {
                                Properties.Settings.Default.rememberUser = true;
                                Properties.Settings.Default.remember_login = textBox_login.Text;
                                Properties.Settings.Default.remember_password = textBox_password.Text;
                            }
                            else
                            {
                                Properties.Settings.Default.rememberUser = false;
                                Properties.Settings.Default.remember_login = string.Empty;
                                Properties.Settings.Default.remember_password = string.Empty;
                            }
                            Properties.Settings.Default.Save();
                            #endregion

                            ThisUser.ID = reader.GetInt32(0);
                            ThisUser.LastName = reader.GetString(1);
                            ThisUser.FirstName = reader.GetString(2);
                            ThisUser.Patronymic = reader.GetString(3);
                            ThisUser.Education = reader.GetString(4);
                            ThisUser.Age = reader.GetInt32(5);
                            ThisUser.Post = (ThisUser.Positions)reader.GetInt32(6);

                            if(reader.GetDateTime(8).Year != 1900)
                            {
                                MessageBox.Show("Вы уволены...");
                                return;
                            }

                            this.Visible = false;
                            textBox_login.Text = string.Empty;
                            textBox_password.Text = string.Empty;

                            switch (ThisUser.Post)
                            {
                                case ThisUser.Positions.Admin: new AdminPanelForm().ShowDialog(); break;
                                case ThisUser.Positions.Manager: new ManagerPanelForm().ShowDialog(); break;

                            }
                            this.Visible = true;
                            LoadRemembreUser();
                            return;
                        }
                    }
                }
            }

        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Enter) return;
            button_log_in_Click(sender, e);
        }
    }
}
