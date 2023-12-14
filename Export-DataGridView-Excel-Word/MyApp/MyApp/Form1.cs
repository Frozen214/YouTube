using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace MyApp
{
    public partial class Form1 : Form
    {
        private WordExporter wordExporter;
        private ExcelExporter excelExporter;
        public Form1()
        {
            wordExporter = new WordExporter();
            excelExporter = new ExcelExporter();
            InitializeComponent();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            wordExporter.WordExport(dataGrid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGrid.Rows.Add("4234", "Молоко", "70");
            dataGrid.Rows.Add("1314", "Печенье", "60");
            dataGrid.Rows.Add("1984", "Хлеб", "40");
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            excelExporter.ExportExcel(dataGrid);
        }
    }
}
