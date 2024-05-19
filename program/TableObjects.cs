using DemoRestaurant;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TableObjects
{
    public class Recipe
    {
        public int id;
        public string title;
        public int cooking_time;
        public string description;
        public int price;
        public Ingredient[] ingredients;

        public int possibleQuantity = 0;

        public Recipe(int id) { this.id = id; LoadData(); }
        public Recipe() { }

        public void LoadData()
        {
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = $"SELECT * FROM `recipe` WHERE `id` = '{this.id}'";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            title = reader.GetString(1);
                            cooking_time = reader.GetInt32(2);
                            description = reader.GetString(3);
                            price = reader.GetInt32(4);
                        }
                    }
                }
            }

            List<Ingredient> ing = new List<Ingredient>();
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query_ = conn.CreateCommand())
                {
                    query_.CommandTimeout = 30;
                    query_.CommandText = "SELECT `ingredients_id` FROM `recipe-ingredients` WHERE `recipe_id` = @id";
                    query_.Parameters.AddWithValue("@id", this.id);

                    using (var reader_ = query_.ExecuteReader())
                    {
                        while (reader_.Read())
                        {
                            ing.Add(new Ingredient(reader_.GetInt32(0)));
                        }
                    }
                }
            }
            ingredients = ing.ToArray();
        }

        public int CalculateQuantity()
        {
            int _n = int.MaxValue;
            foreach (Ingredient ing in ingredients)
            {
                if(_n > ing.count) _n = ing.count;
            }
            possibleQuantity = _n;
            return possibleQuantity;
        }
    }

    public class Ingredient
    {
        public int id;
        public string title;
        public int count;


        public Ingredient(int id)
        {
            this.id = id;
            LoadData();
        }

        public void LoadData()
        {
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = $"SELECT * FROM `ingredients` WHERE `id` = '{this.id}'";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            title = reader.GetString(1);
                            count = reader.GetInt32(2);
                        }
                    }
                }
            }
        }
    }


    public class Positions
    {
        public static Positions[] positions;

        public int id;
        public string technical_name;
        public string title;
        public string duties;
        public string wages;

        public Positions(int _id, string techName, string _title, string _dutise, string _wages)
        {
            id = _id;
            technical_name = techName;
            title = _title;
            duties = _dutise;
            wages = _wages;
        }

        public static void Load()
        {
            List<Positions> list = new List<Positions>();
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                //load positions
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `positions`";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Positions
                                (
                                 reader.GetInt32(0),
                                 reader.GetString(1),
                                 reader.GetString(2),
                                 reader.GetString(3),
                                 reader.GetString(4)
                                ));
                        }
                    }
                }
            } 
            positions = list.ToArray();
        }
    }
}
