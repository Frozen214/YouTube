using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public class DB
    {
        public string stringCon()
        {
            return @"Data Source=user-pc\sqlexpress;Initial Catalog=dbRole;Integrated Security=True";
        }
    }
}
