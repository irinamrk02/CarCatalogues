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
    public partial class FormClientSet : Form
    {
        public FormClientSet()
        {
            InitializeComponent();
            ShowClient();
            ShowAutopart();
        }

        void ShowClient()
        {
            listViewClient.Items.Clear();
            foreach (ClientSet clientSet in Program.catalog.ClientSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    clientSet.Id.ToString(),clientSet.LastName,
                    clientSet.FirstName,clientSet.MiddleName,
                    clientSet.Phone, clientSet.Email,
                    clientSet.AutopartSet.NameAutopart + " - " + clientSet.AutopartSet.CarSet.CarBrand
                });
                item.Tag = clientSet;
                listViewClient.Items.Add(item);
            }
            listViewClient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
                Program.catalog.ClientSet.Add(clientSet);
                Program.catalog.SaveChanges();
                ShowClient();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewClient.SelectedItems.Count == 1)
                {
                    ClientSet clientSet = listViewClient.SelectedItems[0].Tag as ClientSet;
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
                }
                Program.catalog.SaveChanges();
                ShowClient();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewClient.SelectedItems.Count == 1)
                {
                    ClientSet clientSet = listViewClient.SelectedItems[0].Tag as ClientSet;
                    Program.catalog.ClientSet.Remove(clientSet);
                    Program.catalog.SaveChanges();
                    ShowClient();
                }

                textBoxLastName.Text = "";
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
                comboBoxAutopart.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewClient.SelectedItems.Count == 1)
            {
                ClientSet clientSet = listViewClient.SelectedItems[0].Tag as ClientSet;
                textBoxLastName.Text = clientSet.LastName;
                textBoxFirstName.Text = clientSet.FirstName;
                textBoxMiddleName.Text = clientSet.MiddleName;
                textBoxPhone.Text = clientSet.Phone;
                textBoxEmail.Text = clientSet.Email;
                comboBoxAutopart.Text = clientSet.IdAutopart.ToString() + "."
                    + clientSet.AutopartSet.NameAutopart + " - " + clientSet.AutopartSet.CarSet.CarBrand;
            }
            else
            {
                textBoxLastName.Text = "";
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
                comboBoxAutopart.SelectedItem = null;
            }
        }
    }
}
