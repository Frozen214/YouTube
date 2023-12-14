using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public string StringConn = @"Data Source=USER-PC\sqlexpress;Initial Catalog=Eroshkin;Integrated Security=True";

        //старый способ. плохой способ

        //вызов
        private void button1_Click(object sender, EventArgs e)
        {
            var queryListCodeRequest = "SELECT * FROM Пользователи";
            loadElementToComboBox(queryListCodeRequest, "Логин", comboBox1);
        }
        public void loadElementToComboBox(string stringQuery, string column, ComboBox myBox)
        {
            List<string> columnValues = GetColumnValues(stringQuery, column);
            myBox.Items.AddRange(columnValues.ToArray());
        }
        public List<string> GetColumnValues(string query, string columnName)
        {
            List<string> columnValues = new List<string>();

            SqlConnection myCon = new SqlConnection(StringConn);
            myCon.Open();
            using (SqlCommand command = new SqlCommand(query, myCon))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object columnValueObject = reader.GetValue(reader.GetOrdinal(columnName));
                    string columnValue = columnValueObject != DBNull.Value ? columnValueObject.ToString() : "";
                    columnValues.Add(columnValue);
                }
            }
            return columnValues;
        }

        //новый способ. Хороший способ
         public bool FillComboBox(string query, string nameColumn, ComboBox comboBox)
         {
             try
             {
                 using (SqlConnection connection = new SqlConnection(StringConn))
                 {
                     connection.Open();

                     using (SqlCommand command = new SqlCommand(query, connection))
                     {
                         using (SqlDataReader reader = command.ExecuteReader())
                         {
                             while (reader.Read())
                             {
                                 if (!reader.IsDBNull(reader.GetOrdinal(nameColumn)))
                                 {
                                     comboBox.Items.Add(reader[nameColumn].ToString());
                                 }
                             }
                         }
                     }
                 }
                 return true;
             }
             catch (SqlException ex)
             {
                 MessageBox.Show($"Ошибка SQL при заполнении {comboBox}:\r\n {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Ошибка при заполнении {comboBox}:\r\n {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             return false;
         } 

        //вызов
        private void button1_Click(object sender, EventArgs e)
        {
            //обычная загрузка
            FillComboBox("select * from товары", "Стоимость товара", comboBox1);

            //вариант с проверкой, загрузились-ли элементы
            if(db.FillComboBox("select * from товары", "Стоимость товара", comboBox1) != null)
            {
                //успешно загружены элементы.
            }
        }
    }
}
