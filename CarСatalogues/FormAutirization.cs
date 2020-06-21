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
    public struct User
    {
        public string login;
        public string password;
    }

    public partial class FormAutirization : Form
    {
        public static User users = new User();
        public FormAutirization()
        {
            InitializeComponent();
        }
    
    
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" && textBoxCancel.Text == "")
            {
                MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool key = false;
                foreach (Users user in Program.catalog.Users)
                {
                    if (textBoxLogin.Text == user.Login && textBoxCancel.Text == user.Password)
                    {
                        key = true;
                        users.login = user.Login;
                        users.password = user.Password;
                    }
                }

                if (!key)
                {
                    MessageBox.Show("Проверьте данные", "Пользователь не найден", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxLogin.Text = "";
                    textBoxCancel.Text = "";
                }
                else
                {

                    FormAdmin admin = new FormAdmin();
                    admin.Show();
                    this.Hide();

                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }
    }
}
