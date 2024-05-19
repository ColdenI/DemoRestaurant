using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoRestaurant.Cook
{
    public partial class CookPenelForm : Form
    {
        public CookPenelForm()
        {
            InitializeComponent();
        }

        private void button_orders_Click(object sender, EventArgs e)
        {
            Visible = false;
            new CookOrderForm().ShowDialog();
            Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            new CookRecipesPanelForm().ShowDialog();
            Visible = true;
        }
    }
}
