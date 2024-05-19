using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
            using (var conn = new MySqlConnection(Program.SQLBuilder.ConnectionString))
            {
                try{conn.Open();}
                catch{MessageBox.Show("MySQL server disconnect");}
                using (var query = conn.CreateCommand())
                {
                    query.CommandTimeout = 30;
                    query.CommandText = "SELECT `title` FROM `positions`";

                    using (var reader = query.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                        }
                    }
                }
            }

query.Parameters.AddWithValue("@age", age);
query.ExecuteNonQuery(); // без ответа
*/

namespace DemoRestaurant
{
    internal static class Program
    {
        public static MySqlConnectionStringBuilder SQLBuilder;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SQLBuilder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "demorestaurant",
                UserID = "root",
                Password = "password",
                SslMode = MySqlSslMode.Required,
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AuthorizationForm());
            Application.Run(new AuthorizationForm());
        }
    }
}
