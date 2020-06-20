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
    public partial class FormCarSet : Form
    {
        public FormCarSet()
        {
            InitializeComponent();
            ShowCar();
            ShowAutomaker();
        }

        void ShowCar()
        {
            listViewCar.Items.Clear();
            foreach (CarSet car in Program.catalog.CarSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    car.Id.ToString(), car.CarBrand, car.Country,
                    car.Automaker.NameAutomaker + "-" + car.Automaker.Country, car.Year
                });
                item.Tag = car;
                listViewCar.Items.Add(item);
            }
            listViewCar.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        void ShowAutomaker()
        {
            comboBoxAutoMaker.Items.Clear();
            foreach (Automaker maker in Program.catalog.Automaker)
            {
                string[] item = {maker.Id.ToString() + ".", maker.NameAutomaker +
                        "-" + maker.Country};
                comboBoxAutoMaker.Items.Add(string.Join(" ", item));
            }
        }

        private void ListViewCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCar.SelectedItems.Count == 1)
            {
                CarSet car = listViewCar.SelectedItems[0].Tag as CarSet;
                textBoxBrand.Text = car.CarBrand;
                textBoxCountry.Text = car.Country;
                comboBoxAutoMaker.Text = car.IdAutomaker.ToString() + "." +
                    car.Automaker.NameAutomaker + "-" + car.Automaker.Country;
                textBoxYear.Text = car.Year;
            }
            else
            {
                textBoxBrand.Text = "";
                textBoxCountry.Text = "";
                comboBoxAutoMaker.SelectedItem = null;
                textBoxYear.Text = "";
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            CarSet car = new CarSet();
            car.CarBrand = textBoxBrand.Text;
            car.Country = textBoxCountry.Text;
            car.IdAutomaker = Convert.ToInt32(comboBoxAutoMaker.SelectedItem.ToString().Split('.')[0]);
            car.Year = textBoxYear.Text;
            Program.catalog.CarSet.Add(car);
            Program.catalog.SaveChanges();
            ShowCar();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (listViewCar.SelectedItems.Count == 1)
            {
                CarSet car = listViewCar.SelectedItems[0].Tag as CarSet;
                car.CarBrand = textBoxBrand.Text;
                car.Country = textBoxCountry.Text;
                car.IdAutomaker = Convert.ToInt32(comboBoxAutoMaker.SelectedItem.ToString().Split('.')[0]);
                car.Year = textBoxYear.Text;
            }
            Program.catalog.SaveChanges();
            ShowCar();
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewCar.SelectedItems.Count == 1)
                {
                    CarSet car = listViewCar.SelectedItems[0].Tag as CarSet;
                    Program.catalog.CarSet.Remove(car);
                    Program.catalog.SaveChanges();
                    ShowCar();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
