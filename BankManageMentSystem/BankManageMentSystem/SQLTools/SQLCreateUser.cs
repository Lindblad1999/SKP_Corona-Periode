using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManageMentSystem.SQLTools
{
    public static class SQLCreateUser
    {
        public static bool CheckExistingUsername(string usernameUserInput)
        {
            string command = "SELECT Username FROM Logins";

            using (SqlConnection connection = new SqlConnection(ConnectToSQL.connStr.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(command, connection);
                connection.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0) == usernameUserInput)
                        return true;
                }
                connection.Close();
            }
            return false;
        }

        public static void InsertNewUserInDB(User currentUser) 
        {
            //Need autoincrement on userID
            string command = "INSERT INTO Logins VALUES (4, '"+currentUser.Username+"', '"+currentUser.Password+"', 0);";
            string command2 = "INSERT INTO Users VALUES ('"+ currentUser.Firstname +"');";

            using (SqlConnection connection = new SqlConnection(ConnectToSQL.connStr.ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(command, connection);
                SqlCommand sqlCmd2 = new SqlCommand(command2, connection);
                connection.Open();
                sqlCmd2.ExecuteNonQuery();
                sqlCmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
