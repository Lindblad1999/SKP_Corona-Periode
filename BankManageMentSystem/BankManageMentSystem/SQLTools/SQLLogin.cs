using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManageMentSystem.SQLTools;

namespace BankManageMentSystem.SQLTools
{
    public static class SQLLogin
    {
        public static bool CheckLogin(string usernameUserInput, string passwordUserInput)
        {
            string command = "SELECT Username, Password FROM Logins";

            using (SqlConnection connection = new SqlConnection(ConnectToSQL.connStr.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(command, connection);
                connection.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0) == usernameUserInput && reader.GetString(1) == passwordUserInput)
                        return true;
                }
                connection.Close();
            }
            return false;
        }
    }
}
