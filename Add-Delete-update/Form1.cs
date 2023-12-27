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

            //РЕКОМЕНДУЮ!!
            //Способ #2 имеет вариант с проверкой выполнения запроса. Если запрос не выполнился - уведомление с ошибкой
            //выйдет из класса. А уведомление об успешном выполнении - можно менять ниже.

            //var queryAddMark2= $"insert into Марка (Наименование) values ('{textBox1.Text}')";
            //if(db.Execute(queryAddMark2)!=null)
            //{
                //MessageBox.Show("Действие успешно выполнено!", "Успех");
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var queryDeleteMark = $"delete Марка where КодМарки = {textBox2.Text}";
            db.queryExecute(queryDeleteMark);

            //Способ #2 
            //var queryDeleteMark2 = $"delete Марка where КодМарки = {textBox2.Text}";
            //if(db.Execute(queryDeleteMark2)!=null)
            //{
                //MessageBox.Show("Действие успешно выполнено!", "Успех");
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var queryUpdateMark = $"update Марка set Наименование = '{textBox3.Text}' where КодМарки = {textBox4.Text}";
            db.queryExecute(queryAddMark);

            //Способ #2 
            //var queryUpdateMark2 = $"update Марка set Наименование = '{textBox3.Text}' where КодМарки = {textBox4.Text}";
            //if(db.queryExecute(queryUpdateMark2)!=null)
            //{
                //MessageBox.Show("Действие успешно выполнено!", "Успех");
            //}
        }
    }
}
