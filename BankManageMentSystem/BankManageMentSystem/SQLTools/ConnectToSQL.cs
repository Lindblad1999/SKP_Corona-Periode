using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManageMentSystem.SQLTools
{
    public static class ConnectToSQL
    {
        public static SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder();

        public static void ConnectionStringWindowsAuthentication()
        {
            connStr.DataSource = @".";
            connStr.InitialCatalog = "Bank";
            connStr.IntegratedSecurity = true;
        }

        public static void ConnectionStringServerAuthentication()
        {
            connStr.DataSource = @"localhost, 1433";
            connStr.InitialCatalog = "Bank";
            connStr.IntegratedSecurity = false;
            connStr.UserID = "sa";
            connStr.Password = "<Passw0rd>";
        }
    }
}
