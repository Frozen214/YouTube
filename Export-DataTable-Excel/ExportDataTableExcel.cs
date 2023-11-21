using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string con = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=АнализПоведения;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            var query = "select  Дата_покупки, count(Дата_покупки) as [Количество транзакций]" +
                " from Сведения_о_покупке" +
                " where Дата_покупки between '2022-01-09' and '2022-01-10'" +
                " group by Дата_покупки";

            var datatable = new DataTable();

            queryReturnData(query, datatable);

            ExportToExcel(datatable);
        }
        public DataTable queryReturnData(string query, DataTable dataTable)
        {
            SqlConnection myCon = new SqlConnection(con);
            myCon.Open();

            SqlDataAdapter SDA = new SqlDataAdapter(query, myCon);
            SDA.SelectCommand.ExecuteNonQuery();

            SDA.Fill(dataTable);
            return dataTable;
        }
        private void ExportToExcel(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataTable.Columns.Count + 1; i++)
                {
                    excel.Cells[1, i] = dataTable.Columns[i - 1].ColumnName;
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        excel.Cells[i + 2, j + 1] = dataTable.Rows[i][j].ToString();
                    }
                }

                excel.Columns.AutoFit();
                excel.Visible = true;
            }
            else
            {
                MessageBox.Show("No data to export!");
            }
        }
    }
}
