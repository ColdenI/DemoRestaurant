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

namespace DemoRestaurant.Manager
{
    public partial class ManagerPanelForm : Form
    {
        public ManagerPanelForm()
        {
            InitializeComponent();
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
        }

        private void DrawTableOrders()
        {
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
            dgv.Columns.Add("dishes_personnel", "Повар");
            dgv.Columns.Add("delivery_personnel", "Доставщик");

            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }

                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `order`";

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
                                foreach(Dishes i in dishes) if(i == null) continue;         

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
                                Personnel personnel = Personnel.GetPersonnelByID(dishes[0].personnel_id);
                                dgv.Rows[counter].Cells[7].Value = $"{personnel.fname} {personnel.lname} {personnel.patronymic}";
                                personnel = Personnel.GetPersonnelByID(delivery.personnel_id);
                                dgv.Rows[counter].Cells[8].Value = $"{personnel.fname} {personnel.lname} {personnel.patronymic}";


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

        private void toolStripButton_update_Click(object sender, EventArgs e) => DrawTableOrders();

        private void ManagerPanelForm_Load(object sender, EventArgs e)
        {
            DrawTableOrders();
        }

        private void toolStripButton_add_Click(object sender, EventArgs e)
        {
            new AddNewOrderForm().ShowDialog();
            DrawTableOrders();
        }

        private void toolStripButton_removeOrder_Click(object sender, EventArgs e)
        {
            RemoveOrder((int)dgv.CurrentCell.OwningRow.Cells[0].Value, true);
            DrawTableOrders();
        }

        public static void RemoveOrder(int order_id, bool ReturnIngredients = true)
        {
            List<int> ingredientsId = new List<int>();
            if (ReturnIngredients)
            {
                foreach (Dishes i in Dishes.GetDishesByOrderID(order_id))
                {
                    foreach (Ingredient j in Recipe.GetRecipeByID(i.recipe_id).ingredients)
                    {
                        ingredientsId.Add(j.id);
                    }
                }
            }

            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.Parameters.AddWithValue("@order_id", order_id);

                    if (ReturnIngredients)
                    {
                        foreach(int i in ingredientsId)
                        {
                            query.CommandText = $"UPDATE `ingredients` SET `count` = `count` + 1 WHERE `id` = '{i}';";
                            query.ExecuteNonQuery();
                        }
                    }
                    
                    query.CommandText = "DELETE FROM `delivery` WHERE `order_id` = @order_id;";
                    query.ExecuteNonQuery();

                    query.CommandText = "DELETE FROM `dishes` WHERE `order_id` = @order_id;";
                    query.ExecuteNonQuery();

                    int customerId = Customer.GetCustomerByOrderID(order_id).id;

                    query.CommandText = "DELETE FROM `order` WHERE `id` = @order_id;";
                    query.ExecuteNonQuery();

                    query.CommandText = $"DELETE FROM `customer` WHERE `id` = '{customerId}';";
                    query.ExecuteNonQuery();
                }
            }
        }
    }
}
