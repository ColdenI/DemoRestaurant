using DemoRestaurant;
using MySql.Data.MySqlClient;
using System;
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

        public Recipe(int id) {
            Recipe recipe =  Recipe.GetRecipeByID(id); 
            this.id = id;
            title = recipe.title;
            cooking_time = recipe.cooking_time;
            description = recipe.description;
            price = recipe.price;
            ingredients = recipe.ingredients;
        }
        public Recipe() { }

        public static Recipe GetRecipeByID(int id)
        {
            Recipe recipe = new Recipe();
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = $"SELECT * FROM `recipe` WHERE `id` = '{id}'";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            recipe.id = reader.GetInt32(0);
                            recipe.title = reader.GetString(1);
                            recipe.cooking_time = reader.GetInt32(2);
                            recipe.description = reader.GetString(3);
                            recipe.price = reader.GetInt32(4);
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
                    query_.Parameters.AddWithValue("@id", id);

                    using (var reader_ = query_.ExecuteReader())
                    {
                        while (reader_.Read())
                        {
                            ing.Add(new Ingredient(reader_.GetInt32(0)));
                        }
                    }
                }
            }
            recipe.ingredients = ing.ToArray();

            return recipe;
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

        public static Positions GetPositionByID(int id)
        {
            Positions positions = null;
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }
                //load positions
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `positions` WHERE `id` = @id";
                    query.Parameters.AddWithValue("@id", id);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            positions = new Positions
                                (
                                 reader.GetInt32(0),
                                 reader.GetString(1),
                                 reader.GetString(2),
                                 reader.GetString(3),
                                 reader.GetString(4)
                                );
                        }
                    }
                }
            } 
            return positions;
        }
    }

    public class Customer
    {
        public int id;
        public string lname;
        public string fname;
        public string patronymic;
        public string addres;
        public string numberPhone;

        public static Customer GetCustomerByID(int id)
        {
            Customer customer = null;
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }

                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `customer` WHERE `id` = @id";
                    query.Parameters.AddWithValue("@id", id);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer = new Customer();
                            customer.id = reader.GetInt32(0);
                            customer.lname = reader.GetString(1);
                            customer.fname = reader.GetString(2);
                            customer.patronymic = reader.GetString(3);
                            customer.addres = reader.GetString(4);
                            customer.numberPhone = reader.GetString(5);
                        }
                    }
                }
            }
            return customer;
        }
        
        public static Customer GetCustomerByOrderID(int order_id)
        {
            Customer customer = null;
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }

                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT `customer_id` FROM `order` WHERE `id` = @id";
                    query.Parameters.AddWithValue("@id", order_id);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer = GetCustomerByID(reader.GetInt32(0));
                        }
                    }
                }
            }
            return customer;
        }
    }

    public class Delivery
    {
        public int id;
        public DateTime datetime;
        public int order_id;
        public int personnel_id;

        public static Delivery GetDeliveryByID(int id)
        {
            Delivery delivery = null;
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }

                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `delivery` WHERE `id` = @id";
                    query.Parameters.AddWithValue("@id", id);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            delivery = new Delivery();
                            delivery.id = reader.GetInt32(0);
                            delivery.datetime = reader.GetDateTime(1);
                            delivery.personnel_id = reader.GetInt32(2);
                            delivery.order_id = reader.GetInt32(3);
                        }
                    }
                }
            }
            return delivery;
        }

        public static Delivery GetDeliveryByOrderID(int order_id)
        {
            Delivery delivery = null;
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }

                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `delivery` WHERE `order_id` = @id";
                    query.Parameters.AddWithValue("@id", order_id);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            delivery = new Delivery();
                            delivery.id = reader.GetInt32(0);
                            delivery.datetime = reader.GetDateTime(1);
                            delivery.personnel_id = reader.GetInt32(2);
                            delivery.order_id = reader.GetInt32(3);
                        }
                    }
                }
            }
            return delivery;
        }
    }

    public class Personnel
    {
        public int id;
        public string lname;
        public string fname;
        public string patronymic;
        public string education;
        public int age;
        public int post_id;
        public DateTime date_of_employment;
        public DateTime date_of_dismissal;

        public static Personnel GetPersonnelByID(int id)
        {
            Personnel personnel = null;
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }

                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `personnel-data` WHERE `id` = @id";
                    query.Parameters.AddWithValue("@id", id);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            personnel = new Personnel();
                            personnel.id = reader.GetInt32(0);
                            personnel.lname = reader.GetString(1);
                            personnel.fname = reader.GetString(2);
                            personnel.patronymic = reader.GetString(3);
                            personnel.education = reader.GetString(4);
                            personnel.age = reader.GetInt32(5);
                            personnel.post_id = reader.GetInt32(6);
                            personnel.date_of_employment = reader.GetDateTime(7);
                            personnel.date_of_dismissal = reader.GetDateTime(8);
                        }
                    }
                }
            }
            return personnel;
        }
    }

    public class Dishes
    {
        public int id;
        public int order_id;
        public int recipe_id;
        public int personnel_id;

        public static Dishes[] GetDishesByOrderID(int order_id)
        {
            List<Dishes> Ldishes = new List<Dishes>();
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try { conn.Open(); }
                catch { MessageBox.Show("MySQL server disconnect"); }

                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT * FROM `dishes` WHERE `order_id` = @id";
                    query.Parameters.AddWithValue("@id", order_id);

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dishes dishes = new Dishes();
                            dishes.id = reader.GetInt32(0);
                            dishes.order_id = reader.GetInt32(1);
                            dishes.recipe_id = reader.GetInt32(2);
                            dishes.personnel_id = reader.GetInt32(3);
                            Ldishes.Add(dishes);
                        }
                    }
                }
            }
            return Ldishes.ToArray();
        }
    }
}
