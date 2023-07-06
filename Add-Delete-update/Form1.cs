using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class Form1 : Form
    {
        private DB db;
        public Form1()
        {
            db = new DB(); 
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var queryAddMark= $"insert into Марка (Наименование) values ('{textBox1.Text}')";
            db.queryExecute(queryAddMark);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var queryAddMark = $"delete Марка where КодМарки = {textBox2.Text}";
            db.queryExecute(queryAddMark);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var queryAddMark = $"update Марка set Наименование = '{textBox3.Text}' where КодМарки = {textBox4.Text}";
            db.queryExecute(queryAddMark);
        }
    }
}
