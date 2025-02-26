﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TableObjects;
using System.Windows.Forms;

namespace DemoRestaurant
{
    public partial class PersonnelPanel : Form
    {
        public PersonnelPanel()
        {
            InitializeComponent();
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DrawTableUsers();
        }

        private void DrawTableUsers()
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.BringToFront();
            dgv.Dock = DockStyle.Fill;
            dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgv.Columns.Add("id", "id"); dgv.Columns["id"].Visible = false;
            dgv.Columns.Add("lname", "Имя");
            dgv.Columns.Add("fname", "Фамилия");
            dgv.Columns.Add("patronymic", "Отчество");
            dgv.Columns.Add("education", "Образование");
            dgv.Columns.Add("age", "Возраст");
            dgv.Columns.Add("positions_id", "Должность");
            dgv.Columns.Add("wages", "Зарплата");
            dgv.Columns.Add("date_of_employment", "Дата принятия на работу");
            dgv.Columns.Add("date_of_dismissal", "Дата увольнения");

            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `personnel-data`";

                    using (var reader = query.ExecuteReader())
                    {
                        int counter = 0;
                        while (reader.Read())
                        {
                            Positions post = Positions.GetPositionByID(reader.GetInt32(6));

                            dgv.Rows.Add();
                            dgv.Rows[counter].Cells[0].Value = reader.GetInt32(0);
                            dgv.Rows[counter].Cells[1].Value = reader.GetString(1);
                            dgv.Rows[counter].Cells[2].Value = reader.GetString(2);
                            dgv.Rows[counter].Cells[3].Value = reader.GetString(3);
                            dgv.Rows[counter].Cells[4].Value = reader.GetString(4);
                            dgv.Rows[counter].Cells[5].Value = reader.GetInt32(5);
                            dgv.Rows[counter].Cells[6].Value = post.title;
                            dgv.Rows[counter].Cells[7].Value = post.wages;
                            dgv.Rows[counter].Cells[8].Value = reader.GetDateTime(7);
                            DateTime date_of_dismissal = reader.GetDateTime(8);
                            dgv.Rows[counter].Cells[9].Value = (date_of_dismissal.Year == 1900) ? "Не уволен" : date_of_dismissal.ToString();

                            counter++;
                        }
                    }
                }
            }
        }

        private void toolStripButton_editPersonnel_Click(object sender, EventArgs e)
        {
            new ManagementUser((int)dgv.CurrentCell.OwningRow.Cells[0].Value).ShowDialog();
            DrawTableUsers();
        }

        private void toolStripButton_updateTable_Click(object sender, EventArgs e)
        {
            DrawTableUsers();
        }

        private void toolStripButton_addNewPersonnel_Click(object sender, EventArgs e)
        {
            new ManagementUser().ShowDialog();
            DrawTableUsers();
        }
    }
}
