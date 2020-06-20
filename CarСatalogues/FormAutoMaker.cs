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
    public partial class FormAutoMaker : Form
    {
        public FormAutoMaker()
        {
            InitializeComponent();
            ShowAutoMaker();
        }

        void ShowAutoMaker()
        {
            listViewAutomaker.Items.Clear();
            foreach (Automaker maker in Program.catalog.Automaker)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    maker.Id.ToString(), maker.NameAutomaker, maker.Country
                });
                item.Tag = maker;
                listViewAutomaker.Items.Add(item);
            }
            listViewAutomaker.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Automaker maker = new Automaker();
            maker.NameAutomaker = textBoxAutoMaker.Text;
            maker.Country = textBoxCountry.Text;
            Program.catalog.Automaker.Add(maker);
            Program.catalog.SaveChanges();
            ShowAutoMaker();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (listViewAutomaker.SelectedItems.Count == 1)
            {
                Automaker maker = listViewAutomaker.SelectedItems[0].Tag as Automaker;
                maker.NameAutomaker = textBoxAutoMaker.Text;
                maker.Country = textBoxCountry.Text;
                Program.catalog.SaveChanges();
                ShowAutoMaker();
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewAutomaker.SelectedItems.Count == 1)
                {
                    Automaker maker = listViewAutomaker.SelectedItems[0].Tag as Automaker;
                    Program.catalog.Automaker.Remove(maker);
                    Program.catalog.SaveChanges();
                    ShowAutoMaker();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListViewAutomaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAutomaker.SelectedItems.Count == 1)
            {
                Automaker maker = listViewAutomaker.SelectedItems[0].Tag as Automaker;
                textBoxAutoMaker.Text = maker.NameAutomaker;
                textBoxCountry.Text = maker.Country;
            }
            else
            {
                textBoxAutoMaker.Text = "";
                textBoxCountry.Text = "";
            }
        }
    }
}
