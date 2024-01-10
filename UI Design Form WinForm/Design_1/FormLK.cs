using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_1
{
    public partial class FormLK : Form
    {
        private DB db;
        public FormLK()
        {
            db = new DB();
            InitializeComponent();
        }

        private void FormLK_Load(object sender, EventArgs e)
        {
            LoadPersonalData();
        }

        private void LoadPersonalData()
        {
            guna2TextBox10.Text = PersonalData.Login;
            guna2TextBox9.Text = PersonalData.Password;
            guna2TextBox1.Text = PersonalData.LastName;
            guna2TextBox2.Text = PersonalData.FirstName;
            guna2TextBox3.Text = PersonalData.FatherName;
            guna2TextBox4.Text = PersonalData.DateBrth;
            guna2TextBox5.Text = PersonalData.NumberTel;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox10.Text) || string.IsNullOrEmpty(guna2TextBox9.Text))
            {
                MessageBox.Show("Все поля необходимо заполнить", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Изменить логин и пароль?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var queryUpdateData = $" update Пользователи " +
                                      $" Set Логин = '{guna2TextBox10.Text}', Пароль='{guna2TextBox9.Text}' " +
                                      $" where Логин ='{PersonalData.Login}' AND Пароль='{PersonalData.Password}'";
                if (db.Execute(queryUpdateData) != null)
                {
                    MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Действие было отменено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox2.Text) || string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox3.Text) || string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox5.Text))
            {
                MessageBox.Show("Все поля необходимо заполнить", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Изменить личные данные?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var queryUpdateData = $" update с set Фамилия='{guna2TextBox2.Text}', Имя='{guna2TextBox1.Text}',Отчество='{guna2TextBox3.Text}',[Номер телефона]='{guna2TextBox5.Text}',[Дата рождения]='{guna2TextBox4.Text}' " +
                       " from Сотрудники с  " +
                      $" where Фамилия='{PersonalData.FirstName}'AND Имя='{PersonalData.LastName}'AND Отчество='{PersonalData.FatherName}'" +
                      $" AND [Номер телефона]='{PersonalData.NumberTel}'AND [Дата рождения]='{PersonalData.DateBrth}' ";

                if (db.Execute(queryUpdateData) != null)
                {
                    MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Действие было отменено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                guna2TextBox9.UseSystemPasswordChar = false;
            }
            else
            {
                guna2TextBox9.UseSystemPasswordChar = true;
            }
        }
    }
}
