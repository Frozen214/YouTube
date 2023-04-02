using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartGunaApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var creatorChart = new CreatorChart();
            creatorChart.ChartPie(gunaChart1, dataSet(),"Статистика зарплата сотрудников (ChartPie)");
        }
        private DataTable dataSet()
        {
            // Создаем DataTable
            DataTable dataTable = new DataTable("MyTable");

            // Добавляем столбцы
            dataTable.Columns.Add("Сотрудник", typeof(string));
            dataTable.Columns.Add("Зарплата", typeof(double));

            // Добавляем строки
            dataTable.Rows.Add("Петя", 100);
            dataTable.Rows.Add("Вася", 200);
            dataTable.Rows.Add("Олег", 150);
            dataTable.Rows.Add("Денис", 170);

            return dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var creatorChart = new CreatorChart();
            creatorChart.ChartPolar(gunaChart1, dataSet(), "Статистика зарплата сотрудников (ChartPolar)");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var creatorChart = new CreatorChart();
            creatorChart.ChartBar(gunaChart1, dataSet(), "Статистика зарплата сотрудников (ChartBar)");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var creatorChart = new CreatorChart();
            creatorChart.ChartHorizontalBar(gunaChart1, dataSet(), "Статистика зарплата сотрудников (ChartHorizontalBar)");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
