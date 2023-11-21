using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkRole(PersonalData.Role.ToUpper());
        }
        private string checkRole(string role)
        {
            switch (role)
            {
                case ("ПОЛЬЗОВАТЕЛЬ"):
                    guna2Button1.Dispose();
                    guna2Button3.Dispose();
                    MessageBox.Show($"Добро пожаловать {PersonalData.Login}", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return role;
                case ("АДМИН"):
                    guna2Button2.Dispose();
                    guna2Button3.Dispose();
                    MessageBox.Show($"Добро пожаловать {PersonalData.Login}", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return role;
                case ("МЕНЕДЖЕР"):
                    guna2Button1.Dispose();
                    guna2Button2.Dispose();
                    MessageBox.Show($"Добро пожаловать {PersonalData.Login}", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return role;
                default:
                    guna2Button1.Dispose();
                    guna2Button2.Dispose();
                    guna2Button3.Dispose();
                    MessageBox.Show("Учетная запись некорректна.\rОбратитесь в тех. поддержку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return role;
            }
        }
    }
}
