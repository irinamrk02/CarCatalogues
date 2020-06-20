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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void ButtonAutopart_Click(object sender, EventArgs e)
        {
            FormAutopart autopart = new FormAutopart();
            autopart.Show();
            
        }

        private void ButtonCars_Click(object sender, EventArgs e)
        {
            FormCarSet car = new FormCarSet();
            car.Show();
            
        }

        private void ButtonClients_Click(object sender, EventArgs e)
        {
            FormClientSet client = new FormClientSet();
            client.Show();
            
        }

        private void ButtonMaker_Click(object sender, EventArgs e)
        {
            FormAutoMaker maker = new FormAutoMaker();
            maker.Show();
            
        }

        private void ButtonShops_Click(object sender, EventArgs e)
        {
            FormShops shops = new FormShops();
            shops.Show();
            
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {

        }
    }
}
