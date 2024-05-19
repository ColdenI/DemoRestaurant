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
using TableObjects;

namespace DemoRestaurant
{
    public partial class DeliverymanForm : Form
    {
        public DeliverymanForm()
        {
            InitializeComponent();
        }

        private void DeliverymanForm_Load(object sender, EventArgs e)
        {
            DrawTableOrders();
        }

        private void DrawTableOrders()
        {
            //отображать только для этого курьера

            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.BringToFront();
            dgv.Dock = DockStyle.Fill;
            dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgv.Columns.Add("id", "id"); dgv.Columns["id"].Visible = false;
            dgv.Columns.Add("customer_name", "Заказчик");
            dgv.Columns.Add("notes", "Примечания");
            dgv.Columns.Add("customer_addres", "Адрес");
            dgv.Columns.Add("customer_numberPhone", "Номер");
            dgv.Columns.Add("delivery_time", "Дата Время");
            dgv.Columns.Add("dishes", "Блюда");
            dgv.Columns.Add("status", "Статус");

            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }

                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `order` WHERE `status` <> 'Доставлен'";

                    using (var reader = query.ExecuteReader())
                    {
                        int counter = 0;
                        while (reader.Read())
                        {
                            try
                            {
                                Customer customer = Customer.GetCustomerByID(reader.GetInt32(2));
                                Delivery delivery = Delivery.GetDeliveryByOrderID(reader.GetInt32(0));
                                Dishes[] dishes = Dishes.GetDishesByOrderID(reader.GetInt32(0));
                                if (customer == null) continue;
                                if (delivery == null) continue;
                                foreach (Dishes i in dishes) if (i == null) continue;
                                
                                Personnel personnel = Personnel.GetPersonnelByID(delivery.personnel_id);
                                if(personnel.id != ThisUser.ID) continue;
                                if(delivery.datetime > DateTime.Now.AddHours(1)) continue;

                                dgv.Rows.Add();
                                dgv.Rows[counter].Cells[0].Value = reader.GetInt32(0);
                                dgv.Rows[counter].Cells[1].Value = $"{customer.fname} {customer.lname} {customer.patronymic}";
                                dgv.Rows[counter].Cells[2].Value = reader.GetString(1);
                                dgv.Rows[counter].Cells[3].Value = customer.addres;
                                dgv.Rows[counter].Cells[4].Value = customer.numberPhone;
                                dgv.Rows[counter].Cells[5].Value = delivery.datetime.ToString();
                                string dishes_str = string.Empty;
                                for (int i = 0; i < dishes.Length; i++)
                                {
                                    dishes_str += Recipe.GetRecipeByID(dishes[i].recipe_id).title;
                                    if (i != dishes.Length - 1) dishes_str += ", ";
                                }
                                dgv.Rows[counter].Cells[6].Value = dishes_str;
                                dgv.Rows[counter].Cells[7].Value = reader.GetString(3);


                                counter++;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
            }
        }

        private void toolStripButton_UpdateTable_Click(object sender, EventArgs e) => DrawTableOrders();

        private void toolStripButton_setStatus_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "UPDATE `order` SET `status` = @status WHERE `id`=@id;";
                    query.Parameters.AddWithValue("@status", "Доставлен");
                    query.Parameters.AddWithValue("@id", (int)dgv.CurrentCell.OwningRow.Cells[0].Value);
                    query.ExecuteNonQuery();
                }
            }
            DrawTableOrders();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "UPDATE `order` SET `status` = @status WHERE `id`=@id AND `status` <> 'Доставлен';";
                    query.Parameters.AddWithValue("@status", "В пути");
                    query.Parameters.AddWithValue("@id", (int)dgv.CurrentCell.OwningRow.Cells[0].Value);
                    query.ExecuteNonQuery();
                }
            }
            DrawTableOrders();
        }
    }
}
