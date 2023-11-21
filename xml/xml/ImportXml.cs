using System;
using System.Data;
using System.Windows.Forms;

namespace xml
{
    public class ImportXml
    {
        public void LoadXmlDataToDataGridView(string filePath, DataGridView dataGridView)
        {
            try
            {
                DataSet dataSet = new DataSet();

                dataSet.ReadXml(filePath);

                dataGridView.DataSource = null;

                if (dataSet.Tables.Count > 0)
                {
                    dataGridView.DataSource = dataSet.Tables[0];
                }

                MessageBox.Show("Данные из XML файла успешно загружены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных из XML файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
