using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarСatalogues
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonClient_Click(object sender, EventArgs e)
        {
            FormOrder order = new FormOrder();
            order.Show();
            
        }

        private void ButtonAdmin_Click(object sender, EventArgs e)
        {
            FormAutirization admin = new FormAutirization();
            admin.Show();
            this.Hide();
        }
    }
}
