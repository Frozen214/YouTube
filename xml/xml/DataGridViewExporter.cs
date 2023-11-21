using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
namespace xml
{
    public class DataGridViewExporter
    {
        public void ExportToXml(DataGridView dataGridView)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;

            string exportFolderPath = Path.Combine(projectPath, "xmlExport");
            Directory.CreateDirectory(exportFolderPath);

            string fileName = $"Xml_{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}";
            string filePath = Path.Combine(exportFolderPath, fileName);

            XmlDocument xmlDocument = new XmlDocument();

            XmlElement dataElement = xmlDocument.CreateElement("Data");

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                XmlElement rowElement = xmlDocument.CreateElement("Row");
                foreach (DataGridViewCell cell in row.Cells)
                {
                    XmlElement cellElement = xmlDocument.CreateElement(dataGridView.Columns[cell.ColumnIndex].HeaderText);
                    cellElement.InnerText = cell.Value != null ? cell.Value.ToString() : string.Empty;
                    rowElement.AppendChild(cellElement);
                }
                dataElement.AppendChild(rowElement);
            }
            xmlDocument.AppendChild(dataElement);

            try
            {
                xmlDocument.Save(filePath + ".xml");
                MessageBox.Show("Экспорт данных в XML выполнен успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте данных в XML: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}