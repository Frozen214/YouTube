using DGVPrinterHelper;
using ReporterApp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ReporterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var dgvPrinter = new DGVPrinter();
            dgvPrinter.CreateReport("Отчет по тыры пыры...", dataGrid);
        }
        private void FillDataGridView()
        {
            // Создание таблицы данных
            DataTable dataTable = new DataTable();

            // Добавление столбцов
            dataTable.Columns.Add("Column1", typeof(string));
            dataTable.Columns.Add("Column2", typeof(string));
            dataTable.Columns.Add("Column3", typeof(string));
            dataTable.Columns.Add("Column4", typeof(string));

            // Добавление данных в таблицу
            dataTable.Rows.Add("Значение 1", "Значение 2", "Значение 3", "Значение 4");
            dataTable.Rows.Add("Значение 5", "Значение 6", "Значение 7", "Значение 8");
            dataTable.Rows.Add("Значение 9", "Значение 10", "Значение 11", "Значение 12");
            dataTable.Rows.Add("Значение 13", "Значение 14", "Значение 15", "Значение 16");

            // Привязка таблицы данных к DataGridView
            dataGrid.DataSource = dataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }
    }
}
