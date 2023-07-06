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
    }
}
