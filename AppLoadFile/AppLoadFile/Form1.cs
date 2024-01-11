using System;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace AppLoadFile
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private string selectedFilePath; //путь к файлу .txt
        public Form1()
        {
            InitializeComponent();
        }

        //выбираем txt файл
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                label1.Text = $"Файл выбран";
            }
        }

        //загружаем в бд
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Текстовый файл не выбран.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (MySqlConnection connection = new MySqlConnection(DB.stringCon))
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(" INSERT INTO table_file (File) values(@file) ", connection);
                    command.Parameters.Add("@file", MySqlDbType.LongBlob).Value = File.ReadAllBytes(selectedFilePath);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Данные успешно добавлены в базу данных.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении данных в базу данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //просматриваем файл
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                MessageBox.Show("Укажите ID файла.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (MySqlConnection connection = new MySqlConnection(DB.stringCon))
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("SELECT File FROM table_file WHERE id_file = @id", connection);
                    command.Parameters.AddWithValue("@id", guna2TextBox1.Text); 

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        byte[] fileData = (byte[])reader["File"];

                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                        saveFileDialog.FilterIndex = 1;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, fileData);
                            MessageBox.Show("Файл успешно скачан и сохранен на диск.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Файл не найден в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при скачивании файла из базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
