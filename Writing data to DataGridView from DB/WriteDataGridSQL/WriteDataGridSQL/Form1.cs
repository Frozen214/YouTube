using System;
using System.Windows.Forms;

namespace WriteDataGridSQL
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private DB db;
        public Form1()
        {
            db  = new DB(); 
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "select * from dbo.Клиенты";
            if(db.SqlReturnData(query, guna2DataGridView1) != null)
            {
                MessageBox.Show("Запрос успешно выполнен!","Успех",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM CHARACTER_SETS";
            if (db.MySqlReturnData(query, guna2DataGridView1) != null)
            {
                MessageBox.Show("Запрос успешно выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
