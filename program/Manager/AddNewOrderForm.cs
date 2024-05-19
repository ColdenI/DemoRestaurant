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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DemoRestaurant.Manager
{
    public partial class AddNewOrderForm : Form
    {
        private _stR[] _StRs;
        private List<Recipe> _Recipes = new List<Recipe>();

        public AddNewOrderForm()
        {
            InitializeComponent();
        }

        private void AddNewOrderForm_Load(object sender, EventArgs e)
        {
            SetDishesType();
            LoadAllDishes();
            dateTimePicker_datetime.MinDate = DateTime.Now;
        }

        private struct _stR
        {
            public int id;
            public string name;

            public _stR(int _id, string _t) { id = _id;name = _t; }
        }

        private void SetDishesType()
        {
            domainUpDown_dishesType.Items.Clear();
            domainUpDown_dishesType.Items.Add("Другое");
            domainUpDown_dishesType.Items.Add("Горячие");
            domainUpDown_dishesType.Items.Add("Холодные");
            domainUpDown_dishesType.Items.Add("Десерты");
            domainUpDown_dishesType.Items.Add("Закуски");

            domainUpDown_dishesType.SelectedIndex = 0;
        }

        private void LoadAllDishes()
        {
            listBox_allDishes.Items.Clear();
            List<_stR> list = new List<_stR>();
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = $"SELECT `id` FROM `recipe` WHERE `type` = '{domainUpDown_dishesType.SelectedIndex}'";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var i = new Recipe(reader.GetInt32(0));
                            if (i.CalculateQuantity() > 0)
                            {
                                listBox_allDishes.Items.Add(i.title);
                                list.Add(new _stR(i.id, i.title));
                            }                  
                        }
                    }
                }
            }
            _StRs = list.ToArray();
        }

        private void button_addDishes_Click(object sender, EventArgs e)
        {
            if (listBox_allDishes.SelectedIndex == -1) return;

            #region CheckRules
            List<ingr> ings = new List<ingr>();
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT `id`, `count` FROM `ingredients`;";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ings.Add(new ingr(reader.GetInt32(0), reader.GetInt32(1), 0));
                        }
                    }
                }
            }

            foreach (Recipe i in _Recipes)
            {
                foreach (Ingredient j in i.ingredients)
                {
                    for (int n = 0; n < ings.Count; n++)
                    {
                        if (ings[n].id == j.id)
                        {
                            ings[n].need++;
                        }
                    }
                }
            }

            foreach (ingr i in ings)
            {
                if (i.need > i.count)
                {
                    MessageBox.Show("Недостаточно ингредиентов!");
                    return;
                }
            }
            #endregion

            _Recipes.Add(new Recipe(_StRs[listBox_allDishes.SelectedIndex].id));
            UpdateListDishes();
        }

        private void UpdateListDishes()
        {
            listBox_order.Items.Clear();
            foreach(Recipe i in _Recipes)
            {
                listBox_order.Items.Add(i.title);
            }
        }

        private void button_removDishes_Click(object sender, EventArgs e)
        {
            if (listBox_order.SelectedIndex == -1) return;
            _Recipes.RemoveAt(listBox_order.SelectedIndex);
            UpdateListDishes();
        }

        private class ingr
        {
            public int id;
            public int count;
            public int need;

            public ingr(int _id, int _count, int _need) { id=_id; count=_count; need=_need; }
        }

        private void button_addOrder_Click(object sender, EventArgs e)
        {
            #region Check Rules
            if(
                string.IsNullOrEmpty(textBox_lname.Text) || 
                string.IsNullOrEmpty(textBox_fname.Text) || 
                string.IsNullOrEmpty(textBox_addres.Text) || 
                string.IsNullOrEmpty(textBox_numberPhone.Text)
                )
            {
                MessageBox.Show("Заполняет поля.");
                return;
            }

            if(listBox_order.Items.Count <= 0)
            {
                MessageBox.Show("Заполняет поля.");
                return;
            }

            List<ingr> ings = new List<ingr>();
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT `id`, `count` FROM `ingredients`;";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ings.Add(new ingr(reader.GetInt32(0), reader.GetInt32(1), 0));
                        }
                    }
                }
            }

            foreach(Recipe i in _Recipes)
            {
                foreach (Ingredient j in i.ingredients)
                {
                    for (int n = 0; n < ings.Count; n++)
                    {
                        if (ings[n].id == j.id)
                        {
                            ings[n].need++;
                        }
                    }
                }
            }

            foreach(ingr i in ings)
            {
                if(i.need > i.count)
                {
                    MessageBox.Show("Недостаточно ингредиентов. Изменить заказ.");
                    return;
                } 
            }

            #endregion

            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "INSERT INTO `customer` (`last_name`, `first_name`, `patronymic`, `addres`, `number_phone`) VALUES(@lname, @fname, @patronymic, @addres, @number_phone);";
                    query.Parameters.AddWithValue("@lname", textBox_lname.Text);
                    query.Parameters.AddWithValue("@fname", textBox_fname.Text);
                    query.Parameters.AddWithValue("@patronymic", textBox_patronymic.Text);
                    query.Parameters.AddWithValue("@addres", textBox_addres.Text);
                    query.Parameters.AddWithValue("@number_phone", textBox_numberPhone.Text);
                    query.ExecuteNonQuery();

                    query.CommandText = "INSERT INTO `order` (`notes`, `customer_id`, `status`) VALUES (@notes, @customer_id, @status);";
                    query.Parameters.AddWithValue("@notes", textBox_notes.Text);
                    query.Parameters.AddWithValue("@status", "Создан");
                    query.Parameters.AddWithValue("@customer_id", GetID("customer"));
                    query.ExecuteNonQuery();

                    query.Parameters.AddWithValue("@order_id", GetID("order"));
                    int CookID = GetPersonnelId(ThisUser.Positions.Cook);
                    foreach (Recipe i in _Recipes)
                    {
                        query.CommandText = $"INSERT INTO `dishes` (`order_id`, `recipe_id`, `personnel-data_id`) VALUES (@order_id, '{i.id}', '{CookID}');";
                        query.ExecuteNonQuery();
                        foreach(Ingredient j in i.ingredients)
                        {
                            query.CommandText = $"UPDATE `ingredients` SET `count` = `count` - 1 WHERE `id` = '{j.id}';";
                            query.ExecuteNonQuery();
                        }
                    }

                    query.CommandText = "INSERT INTO `delivery` (`date_time`, `personnel-data_id`, `order_id`) VALUES (@date_time, @personnel_data_id, @order_id);";
                    query.Parameters.AddWithValue("@date_time", dateTimePicker_datetime.Value);
                    query.Parameters.AddWithValue("@personnel_data_id", GetPersonnelId(ThisUser.Positions.Deliveryman));
                    query.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Заказ доблен.");
            this.Close();
        }

        private static int GetID(string table)
        {
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = $"SELECT MAX(`id`) FROM `{table}`;";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                return reader.GetInt32(0);
                            }
                            catch
                            {
                                return 1;
                            }
                        }
                    }
                }
            }
            return -1;
        }

        private int GetPersonnelId(ThisUser.Positions positions)
        {
            List<int> personnelIds = new List<int>();
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = $"SELECT `id` FROM `personnel-data` WHERE `positions_id` = '{(int)positions}' AND `date_of_dismissal` = '1900-01-01';";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            personnelIds.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            return personnelIds[new Random().Next(0, personnelIds.Count)];
        }
        

        private void domainUpDown_dishesType_SelectedItemChanged(object sender, EventArgs e)
        {
            LoadAllDishes();
        }

        private void listBox_allDishes_DoubleClick(object sender, EventArgs e)
        {
            button_addDishes_Click(sender, e);
        }
    }
}
