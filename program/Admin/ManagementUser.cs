using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DemoRestaurant
{
    public partial class ManagementUser : Form
    {

        private int personalID = -1;

        public ManagementUser(int _personalId = -1)
        {
            InitializeComponent();

            personalID = _personalId;
            if(personalID == -1)
            {
                Text = "Добавить";
                button_add_edit.Text = Text;
                button_dismiss.Visible = false;
                button_reinstate.Visible = false;
            }
            else
            {
                Text = "Изменить";
                button_add_edit.Text = Text;
            }
        }

        private void ManagementUser_Load(object sender, EventArgs e)
        {
            LoadComboBoxItems();

            if (personalID != -1) LoadDataInUI();
        }

        /// <summary>
        /// Загрузка должностей из базы в список
        /// </summary>
        private void LoadComboBoxItems()
        {
            comboBox_post.Items.Clear();
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
                    query.CommandText = "SELECT `title` FROM `positions`";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox_post.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Загрузка данных из базы в элементы интерфейса
        /// </summary>
        private void LoadDataInUI()
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
                    query.CommandText = "SELECT * FROM `personnel-data` WHERE `id` = @id;";
                    query.Parameters.AddWithValue("@id", personalID);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox_lname.Text = reader.GetString(1);
                            textBox_fname.Text = reader.GetString(2);
                            textBox_patronymic.Text = reader.GetString(3);
                            textBox_education.Text = reader.GetString(4);
                            numericUpDown_age.Value = reader.GetInt32(5);
                            comboBox_post.SelectedIndex = reader.GetInt32(6);
                            label_workStart.Text = reader.GetDateTime(7).ToString("dd/MM/yyyy");
                            DateTime _we = reader.GetDateTime(8);
                            if (_we.Year != 1900)
                            {
                                label_workEnd.Text = _we.ToString("dd/MM/yyyy");
                                label_workEnd.ForeColor = Color.Red;
                                button_dismiss.Enabled = false;
                                button_reinstate.Enabled = true;
                            }
                            else
                            {
                                label_workEnd.Text = "Не уволен.";
                                label_workEnd.ForeColor = Color.Green;
                                button_dismiss.Enabled = true;
                                button_reinstate.Enabled = false;
                            }
                        }
                    }
                    query.CommandText = "SELECT `login`, `password` FROM `personnel-authorization` WHERE `personnel-data_id` = @id;";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox_login.Text = reader.GetString(0);
                            textBox_password.Text = reader.GetString(1);
                        }
                    }
                }
            }
        }

        private void button_add_edit_Click(object sender, EventArgs e)
        {
            #region CheckRules
            if (
                string.IsNullOrEmpty(textBox_login.Text) || 
                string.IsNullOrEmpty(textBox_password.Text) || 
                string.IsNullOrEmpty(textBox_lname.Text) || 
                string.IsNullOrEmpty(textBox_fname.Text) || 
                string.IsNullOrEmpty(textBox_education.Text) || 
                comboBox_post.SelectedIndex == -1 ||
                textBox_login.Text.Length < 8 ||
                textBox_password.Text.Length < 8 
                )
            {
                MessageBox.Show("Заполните все поля!\nЛогин и пароль минимум 8 символов.");
                return;
            }

            bool isCorrLogin = false;
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT COUNT(*) FROM `personnel-authorization` WHERE `login` = @login;";
                    query.Parameters.AddWithValue("@login", textBox_login.Text);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read()) isCorrLogin = (reader.GetInt32(0) == 0);
                    }
                }
            }
            if (!isCorrLogin && personalID == -1)
            {
                MessageBox.Show("Этот логин уже занят!");
                return;
            }
            #endregion

            #region Edit
            if (personalID != -1)
            {      
                using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
                {
                    try { conn.Open(); }
                    catch { MessageBox.Show("MySQL server disconnect"); }
                    using (var query = conn.CreateCommand())
                    {
                        query.CommandTimeout = 30;
                        query.CommandText = "UPDATE `personnel-data` SET `last_name` = @lname, `first_name` = @fname, `patronymic` = @patronymic, `education` = @education, `age` = @age, `positions_id` = @positions_id WHERE `id` = @id;";
                        query.Parameters.AddWithValue("@id", personalID);
                        query.Parameters.AddWithValue("@lname", textBox_lname.Text);
                        query.Parameters.AddWithValue("@fname", textBox_fname.Text);
                        query.Parameters.AddWithValue("@patronymic", textBox_patronymic.Text);
                        query.Parameters.AddWithValue("@education", textBox_education.Text);
                        query.Parameters.AddWithValue("@age", numericUpDown_age.Value.ToString());
                        query.Parameters.AddWithValue("@positions_id", comboBox_post.SelectedIndex);
                        //query.Parameters.AddWithValue("@date_of_dismissal", );
                        query.ExecuteNonQuery();

                        query.CommandText = "UPDATE `personnel-authorization` SET `login` = @login, `password`=@password WHERE `personnel-data_id` = @id;";
                        query.Parameters.AddWithValue("@login", textBox_login.Text);
                        query.Parameters.AddWithValue("@password", textBox_password.Text);
                        query.ExecuteNonQuery();
                    }
                }
            }
            #endregion

            #region Add
            else
            {
                int free_id = -1;
                using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
                {
                    try { conn.Open(); }
                    catch { MessageBox.Show("MySQL server disconnect"); }
                    using (var query = conn.CreateCommand())
                    {
                        query.CommandTimeout = 30;
                        query.CommandText = "SELECT COUNT(*) FROM `personnel-data`";

                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                free_id = reader.GetInt32(0) + 1;
                            }
                        }
                    }
                }
                
                if(free_id == -1)
                {
                    MessageBox.Show("Error\nno free id found!");
                    return;
                }
                using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
                {
                    try { conn.Open(); }
                    catch { MessageBox.Show("MySQL server disconnect"); }
                    using (var query = conn.CreateCommand())
                    {
                        query.CommandTimeout = 30;
                        query.CommandText = "INSERT INTO `personnel-data` (`id`, `last_name`, `first_name`, `patronymic`, `education`, `age`, `positions_id`, `date_of_employment`) VALUE (@id, @last_name, @first_name, @patronymic, @education, @age, @positions_id, @date_of_employment);";
                        query.Parameters.AddWithValue("@id", free_id);
                        query.Parameters.AddWithValue("@last_name", textBox_lname.Text);
                        query.Parameters.AddWithValue("@first_name", textBox_fname.Text);
                        query.Parameters.AddWithValue("@patronymic", textBox_patronymic.Text);
                        query.Parameters.AddWithValue("@education", textBox_education.Text);
                        query.Parameters.AddWithValue("@age", numericUpDown_age.Value.ToString());
                        query.Parameters.AddWithValue("@positions_id", comboBox_post.SelectedIndex);
                        query.Parameters.AddWithValue("@date_of_employment", DateTime.Now.ToString("yyyy-MM-dd"));
                        //query.Parameters.AddWithValue("@date_of_dismissal", );
                        query.ExecuteNonQuery();

                        query.CommandText = "INSERT INTO `personnel-authorization` (`login`, `password`, `personnel-data_id`) VALUE (@login, @password, @id);";
                        query.Parameters.AddWithValue("@login", textBox_login.Text);
                        query.Parameters.AddWithValue("@password", textBox_password.Text);
                        query.ExecuteNonQuery();

                    }
                }
                MessageBox.Show("Успешно!");
                this.Close();
            }
            #endregion

            MessageBox.Show("Успешно!");
            return;
        }

        /// <summary>
        /// Уволить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_dismiss_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "UPDATE `personnel-data` SET `date_of_dismissal` = @date_of_dismissal WHERE `id` = @id;";
                    query.Parameters.AddWithValue("@id", personalID);
                    query.Parameters.AddWithValue("@date_of_dismissal", DateTime.Now.ToString("yyyy-MM-dd"));
                    query.ExecuteNonQuery();
                }
            }

            LoadDataInUI();
        }

        /// <summary>
        /// Восстановить в должности    
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_reinstate_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "UPDATE `personnel-data` SET `date_of_dismissal` = '1900-01-01', `date_of_employment` = @date_of_employment WHERE `id` = @id;";
                    query.Parameters.AddWithValue("@id", personalID);
                    query.Parameters.AddWithValue("@date_of_employment", DateTime.Now.ToString("yyyy-MM-dd"));
                    query.ExecuteNonQuery();
                }
            }

            LoadDataInUI();
        }
    }
}
