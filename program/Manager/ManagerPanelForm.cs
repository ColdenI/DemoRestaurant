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

namespace DemoRestaurant.Manager
{
    public partial class ManagerPanelForm : Form
    {
        public ManagerPanelForm()
        {
            InitializeComponent();
        }

        private void DrawOrders()
        {
            dgv.Rows.Clear();
            dgv.BringToFront();
            dgv.Dock = DockStyle.Fill;
            dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgv.Columns.Add("customer_name", "Заказчик");
            dgv.Columns.Add("notes", "Примечания");
            dgv.Columns.Add("addres", "Адрес");
            dgv.Columns.Add("customer_numberPhone", "Номер");
            dgv.Columns.Add("delivery_time", "Дата Время");
            dgv.Columns.Add("dishes", "Блюда");
            dgv.Columns.Add("dishes_personnel", "Повар");
            dgv.Columns.Add("delivery_personnel", "Доставщик");

            int countLine = 0;

            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT COUNT(*) FROM `order`";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            countLine = reader.GetInt32(0);
                        }
                    }
                }
            }

            Console.WriteLine(countLine.ToString());
        }

        private void toolStripButton_update_Click(object sender, EventArgs e) => DrawOrders();

        private void ManagerPanelForm_Load(object sender, EventArgs e)
        {
            DrawOrders();
        }

        private void toolStripButton_add_Click(object sender, EventArgs e)
        {
            new AddNewOrderForm().ShowDialog();
        }
    }
}
