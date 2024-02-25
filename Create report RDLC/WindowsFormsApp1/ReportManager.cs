using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ReportManager
    {
        public void LoadReport(DataTable dataTable, string nameReport, ReportViewer reportViewer)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"..\..\{nameReport}.rdlc");
            reportViewer.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dataTable);
            reportViewer.LocalReport.ReportPath = path;
            reportViewer.LocalReport.DataSources.Add(source);
            reportViewer.RefreshReport();
        }
    }
}
