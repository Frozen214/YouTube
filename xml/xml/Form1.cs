using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace xml
{
    public partial class FormExampleXML : Form
    {
        public FormExampleXML()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var exportXml = new DataGridViewExporter();
            exportXml.ExportToXml(guna2DataGridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Add("4234", "Молоко", "70");
            guna2DataGridView1.Rows.Add("1314", "Печенье", "60");
            guna2DataGridView1.Rows.Add("1984", "Хлеб", "40");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML файлы (*.xml)|*.xml";
            openFileDialog.Title = "Выберите XML файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                var importXml = new ImportXml();
                importXml.LoadXmlDataToDataGridView(filePath, guna2DataGridView2);
            }
        }
    }
}

