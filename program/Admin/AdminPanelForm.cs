using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoRestaurant.Admin
{
    public partial class AdminPanelForm : Form
    {
        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private void button_personnelPanel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new PersonnelPanel().ShowDialog();
            this.Visible = true;
        }

        private void button_shiftsPanel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ShiftsPanelForm().ShowDialog();
            this.Visible = true;
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            label2.Text = $"{ThisUser.LastName} {ThisUser.FirstName} {ThisUser.Patronymic}";
        }
    }
}
