using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class DatabaseManager
    {
        private string connectionString = @"Data Source=HOME-PC\SQLEXPRESS;Initial Catalog=AdventureWorksDW2008R2;Integrated Security=True";

        public DataTable ExecuteQuery(string sqlQuery)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    using (SqlDataAdapter dp = new SqlDataAdapter(cmd))
                    {
                        dp.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dt;
        }
    }
}