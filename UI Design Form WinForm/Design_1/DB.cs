using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_1
{
    public class DB
    {
        public string StringCon = @"Data Source=user-pc\sqlexpress;Initial Catalog=dbRole;Integrated Security=True";
        public SqlDataAdapter Execute(string query)
        {
            try
            {
                using (SqlConnection myCon = new SqlConnection(StringCon))
                {
                    myCon.Open();
                    if (myCon.State != ConnectionState.Open)
                    {
                        MessageBox.Show("Не удалось установить подключение к базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                    SqlDataAdapter sda = new SqlDataAdapter(query, myCon);
                    sda.SelectCommand.ExecuteNonQuery();
                    return sda;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
