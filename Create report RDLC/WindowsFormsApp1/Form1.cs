using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ReportManager reportManager = new ReportManager();
        DatabaseManager dbManager = new DatabaseManager();
        public Form1()
        {
            reportViewer1 = new ReportViewer();
            dbManager = new DatabaseManager();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = dbManager.ExecuteQuery("SELECT TOP 10 * FROM DatabaseLog dl ORDER BY  dl.DatabaseLogID DESC");
            reportManager.LoadReport(dt,"Report1",reportViewer1);
        }
    }
}
