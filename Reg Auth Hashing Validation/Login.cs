using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diplon
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (boxShowPassword.Checked)
                passwordTextBoxA.UseSystemPasswordChar = true;
            else
                passwordTextBoxA.UseSystemPasswordChar = false;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var login = loginTextBoxA.Text;
            var password = passwordTextBoxA.Text;
            if (login == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
                return;
            }

            if (AuthorizeUser(login, password))
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка");
            }
        }
        private bool AuthorizeUser(string login, string password)
        {
            bool isAuthorized = false;

            var dbQeury = new DBquery();
            var getHash = new Hashing();

            using (SqlConnection con = new SqlConnection(dbQeury.StringCon()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM Пользователи WHERE Логин ='{login}' and Пароль = '{getHash.Hash(password)}'", con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["Пароль"].ToString() == getHash.Hash(password) && reader["Логин"].ToString() == login)
                            {
                                isAuthorized = true;
                                MessageBox.Show("Вход успешно выполнен!","Успех");
                            }
                        }
                    }
                }
            }
            return isAuthorized;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Registration Reg = new Registration();
            Reg.Show();
            this.Hide();
        }
    }
}
