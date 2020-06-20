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
    public partial class FormAutopart : Form
    {
        public FormAutopart()
        {
            InitializeComponent();
            ShowAutoPart();
            ShowAutomaker();
            ShowCar();
        }

        void ShowAutoPart()
        {
            listViewAutopart.Items.Clear();
            foreach (AutopartSet autopart in Program.catalog.AutopartSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    autopart.Id.ToString(), autopart.NameAutopart, 
                    autopart.Automaker.NameAutomaker, autopart.CarSet.CarBrand,
                    autopart.Quantity.ToString(), autopart.Price.ToString() 
                });
                item.Tag = autopart;
                listViewAutopart.Items.Add(item);
            }
            listViewAutopart.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        void ShowAutomaker()
        {
            comboBoxAutoMaker.Items.Clear();
            foreach (Automaker maker in Program.catalog.Automaker)
            {
                string[] item = {maker.Id.ToString() + ".", maker.NameAutomaker + " - " +  maker.Country};
                comboBoxAutoMaker.Items.Add(string.Join(" ", item));
            }
        }

        void ShowCar()
        {
            comboBoxCar.Items.Clear();
            foreach (CarSet car in Program.catalog.CarSet)
            {
                string[] item = {car.Id.ToString() + ".", car.CarBrand };
                comboBoxCar.Items.Add(string.Join(" ", item));
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AutopartSet autopart = new AutopartSet();
            autopart.NameAutopart = textBoxAutoPart.Text;
            autopart.IdAutomaker = Convert.ToInt32(comboBoxAutoMaker.SelectedItem.ToString().Split('.')[0]);
            autopart.IdCar = Convert.ToInt32(comboBoxCar.SelectedItem.ToString().Split('.')[0]);
            autopart.Quantity = Convert.ToInt32(textBoxKol.Text);
            autopart.Price = Convert.ToInt32(textBoxPrice.Text);
            Program.catalog.AutopartSet.Add(autopart);
            Program.catalog.SaveChanges();
            ShowAutoPart();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (listViewAutopart.SelectedItems.Count == 1)
            {
                AutopartSet autopart = listViewAutopart.Items[0].Tag as AutopartSet;
                autopart.NameAutopart = textBoxAutoPart.Text;
                autopart.IdAutomaker = Convert.ToInt32(comboBoxAutoMaker.SelectedItem.ToString().Split('.')[0]);
                autopart.IdCar = Convert.ToInt32(comboBoxCar.SelectedItem.ToString().Split('.')[0]);
                autopart.Quantity = Convert.ToInt32(textBoxKol.Text);
                autopart.Price = Convert.ToInt32(textBoxPrice.Text);
            }
            Program.catalog.SaveChanges();
            ShowAutoPart();
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewAutopart.SelectedItems.Count == 1)
                {
                    AutopartSet autopart = listViewAutopart.Items[0].Tag as AutopartSet;
                    Program.catalog.AutopartSet.Remove(autopart);
                    Program.catalog.SaveChanges();
                    ShowAutoPart();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListViewAutopart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAutopart.SelectedItems.Count == 1)
            {
                AutopartSet autopart = listViewAutopart.Items[0].Tag as AutopartSet;
                textBoxAutoPart.Text = autopart.NameAutopart;
                comboBoxAutoMaker.Text = autopart.IdAutomaker.ToString() + ". "
                    + autopart.Automaker.NameAutomaker;
                comboBoxCar.Text = autopart.IdCar + ". " + autopart.CarSet.CarBrand;
                textBoxKol.Text = autopart.Quantity.ToString();
                textBoxPrice.Text = autopart.Price.ToString();
            }
            else
            {
                textBoxAutoPart.Text = "";
                comboBoxAutoMaker.SelectedItem = null;
                comboBoxCar.SelectedItem = null;
                textBoxKol.Text = "";
                textBoxPrice.Text = "";
            }
        }
    }
}
