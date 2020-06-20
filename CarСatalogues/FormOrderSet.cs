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
    public partial class FormOrderSet : Form
    {
        public FormOrderSet()
        {
            InitializeComponent();
        }

        void ShowClients()
        {
            comboBoxOrder.Items.Clear();
            foreach (ClientSet client in Program.catalog.ClientSet)
            {
                string[] item = {client.Id.ToString() + ". ", client.LastName + " "
                 + client.FirstName + " " + client.MiddleName,
                 "Запчасть: " + client.IdAutopart.ToString() + ".", client.AutopartSet.NameAutopart};
                comboBoxOrder.Items.Add(string.Join(" ", item));
            }
        }
        void ShowOrder()
        {
            listViewOrder.Items.Clear();
            foreach (OrderSet order in Program.catalog.OrderSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    order.Id.ToString(),
                    order.IdClient.ToString(),
                    order.ClientSet.LastName + " " + order.ClientSet.FirstName + " " + order.ClientSet.MiddleName,
                    order.ClientSet.IdAutopart.ToString(),
                    order.ClientSet.AutopartSet.NameAutopart
                });
                item.Tag = order;
                listViewOrder.Items.Add(item);
            }
            listViewOrder.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ListViewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count == 1)
            {
                OrderSet orderSet = listViewOrder.SelectedItems[0].Tag as OrderSet;

                comboBoxOrder.Text = orderSet.IdClient.ToString() + " " + orderSet.ClientSet.LastName +
                    " " + orderSet.ClientSet.FirstName + " " + orderSet.ClientSet.MiddleName + " " +
                    orderSet.ClientSet.IdAutopart.ToString() + " " + orderSet.ClientSet.AutopartSet.NameAutopart;
            }
            else
            {
                comboBoxOrder.SelectedItem = null;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OrderSet order = new OrderSet();

                if (comboBoxOrder.SelectedItem != null)
                    order.IdClient = Convert.ToInt32(comboBoxOrder.SelectedItem.ToString().Split('.')[0]);
                else throw new Exception("Обязательные данные не заполнены");
                               
                Program.catalog.OrderSet.Add(order);
                Program.catalog.SaveChanges();
                ShowOrder();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewOrder.SelectedItems.Count == 1)
                {
                    OrderSet order = listViewOrder.SelectedItems[0].Tag as OrderSet;

                    Program.catalog.OrderSet.Remove(order);
                    Program.catalog.SaveChanges();
                    ShowOrder();
                }
                comboBoxOrder.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
    }
}
