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
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
            ShowBrand();
            ShowAutomaker();
            ShowAutopart();
            ShowShop();
        }

        void ShowBrand()
        {
            comboBoxCarBrand.Items.Clear();
            foreach (CarSet car in Program.catalog.CarSet)
            {
                string[] item = {car.CarBrand};
                comboBoxCarBrand.Items.Add(string.Join(" ", item));
            }
        }

        void ShowAutomaker()
        {
            comboBoxAutomaker.Items.Clear();
            foreach (Automaker maker in Program.catalog.Automaker)
            {
                string[] item = { maker.NameAutomaker + " - " + maker.Country};
                comboBoxAutomaker.Items.Add(string.Join(" ", item));
            }
        }

        void ShowAutopart()
        {
            comboBoxAutopart.Items.Clear();
            foreach (AutopartSet part in Program.catalog.AutopartSet)
            {
                string[] item = {part.Id.ToString() + ".", part.NameAutopart,
                    "Цена: " + part.Price.ToString() + " р." };
                comboBoxAutopart.Items.Add(string.Join(" ", item));
            }
        }

        void ShowShop()
        {
            listViewShop.Items.Clear();
            foreach (Shops shop in Program.catalog.Shops)
            {
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                    shop.Id.ToString(), shop.NameShop, shop.Address,
                    shop.AutopartSet.NameAutopart + " " + shop.AutopartSet.CarSet.CarBrand,
                    shop.AutopartSet.Price.ToString()
                    });
                    item.Tag = shop;
                    listViewShop.Items.Add(item);
                }
                listViewShop.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            try
            {
                ClientSet clientSet = new ClientSet();
                if (textBoxLastName.Text == "" || textBoxFirstName.Text == "" || textBoxMiddleName.Text == "" ||
                    textBoxPhone.Text == "" || comboBoxAutopart.SelectedItem == null)
                { throw new Exception("Обязательные данные не заполнены"); }
                else
                {
                    clientSet.LastName = textBoxLastName.Text;
                    clientSet.FirstName = textBoxFirstName.Text;
                    clientSet.MiddleName = textBoxMiddleName.Text;
                    clientSet.Phone = textBoxPhone.Text;
                    clientSet.IdAutopart = Convert.ToInt32(comboBoxAutopart.SelectedItem.ToString().Split('.')[0]);
                }
                clientSet.Email = textBoxEmail.Text;
                MessageBox.Show("Ваш заказ успешно офоромлен!", "Заказ оформлен",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm formMain = new MainForm();
                formMain.Show();
                this.Hide();
                Program.catalog.ClientSet.Add(clientSet);
                Program.catalog.SaveChanges();
                
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }
    }
}
