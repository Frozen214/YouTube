using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public class DB
    {
        public string StringCon()
        {
            return @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=CarShopTG;Integrated Security=True";
        }
        //простой способ.
        public SqlDataAdapter queryExecute(string query)
        {
            try
            {
                SqlConnection myCon = new SqlConnection(StringCon());
                myCon.Open();

                SqlDataAdapter SDA = new SqlDataAdapter(query, myCon);

                SDA.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Действие успешно выполнено!", "Успех");
                return SDA;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при выполнении запроса.", "Ошибка");
                return null;
            }
        }

        //РЕКОМЕНДУЮ!! Способ #2. Продвинутый способ. более гибкий по отлову ошибок.
        public SqlDataAdapter Execute(string query)
        {
             try
             {
                 using (SqlConnection myCon = new SqlConnection(StringCon())))
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
