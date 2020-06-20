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
    public partial class FormShops : Form
    {
        public FormShops()
        {
            InitializeComponent();
            ShowShop();
            ShowAutopart();
        }

        void ShowShop()
        {
            listViewShops.Items.Clear();
            foreach (Shops shop in Program.catalog.Shops)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    shop.Id.ToString(), shop.NameShop, shop.Address,
                    shop.AutopartSet.NameAutopart + " " + shop.AutopartSet.CarSet.CarBrand,
                    shop.AutopartSet.Quantity.ToString(), shop.AutopartSet.Price.ToString()
                });
                item.Tag = shop;
                listViewShops.Items.Add(item);
            }
            listViewShops.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        void ShowAutopart()
        {
            comboBoxAutopart.Items.Clear();
            foreach (AutopartSet autopart in Program.catalog.AutopartSet)
            {
                string[] item = {autopart.Id.ToString() + ".", autopart.NameAutopart,
                autopart.CarSet.CarBrand};
                comboBoxAutopart.Items.Add(string.Join(" ", item));
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Shops shop = new Shops();
                if (textBoxShop.Text == "" || textBoxAddress.Text == "" || comboBoxAutopart.SelectedItem == null)
                { throw new Exception("Обязательные данные не заполнены"); }
                else
                {
                    shop.NameShop = textBoxShop.Text;
                    shop.Address = textBoxAddress.Text;
                    shop.IdAutopart = Convert.ToInt32(comboBoxAutopart.SelectedItem.ToString().Split('.')[0]);
                }
                Program.catalog.Shops.Add(shop);
                Program.catalog.SaveChanges();
                ShowShop();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewShops.SelectedItems.Count == 1)
                {
                    Shops shop = listViewShops.SelectedItems[0].Tag as Shops;
                    if (textBoxShop.Text == "" || textBoxAddress.Text == "" || comboBoxAutopart.SelectedItem == null)
                    { throw new Exception("Обязательные данные не заполнены"); }
                    else
                    {
                        shop.NameShop = textBoxShop.Text;
                        shop.Address = textBoxAddress.Text;
                        shop.IdAutopart = Convert.ToInt32(comboBoxAutopart.SelectedItem.ToString().Split('.')[0]);
                    }
                }
                    Program.catalog.SaveChanges();
                    ShowShop();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewShops.SelectedItems.Count == 1)
                {
                    Shops shop = listViewShops.SelectedItems[0].Tag as Shops;
                    Program.catalog.Shops.Remove(shop);
                    Program.catalog.SaveChanges();
                    ShowShop();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListViewShops_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewShops.SelectedItems.Count == 1)
            {
                Shops shop = listViewShops.SelectedItems[0].Tag as Shops;
                textBoxShop.Text = shop.NameShop;
                textBoxAddress.Text = shop.Address;
                comboBoxAutopart.Text = shop.IdAutopart.ToString() + "." + shop.AutopartSet.NameAutopart 
                    + " " + shop.AutopartSet.CarSet.CarBrand;
            }
            else
            {
                textBoxShop.Text = "";
                textBoxAddress.Text = "";
                comboBoxAutopart.SelectedItem = null;
            }
        }
    }
}
