using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRestaurant
{
    internal class ThisUser
    {
        public static int ID {  get; set; }
        public static string LastName { get; set; }
        public static string FirstName { get; set; }
        public static string Patronymic { get; set; }
        public static string Education { get; set; }
        public static int Age { get; set; }
        public static Positions Post {  get; set; }

        /// <summary>
        /// Должности
        /// </summary>
        public enum Positions
        {
            /// <summary>
            /// Администратор
            /// </summary>
            Admin = 0,
            /// <summary>
            /// Менеджер
            /// </summary>
            Manager = 1,
            /// <summary>
            /// Доставщик
            /// </summary>
            Deliveryman = 2,
            /// <summary>
            /// Повар
            /// </summary>
            Cook = 3
        }
    }
}
