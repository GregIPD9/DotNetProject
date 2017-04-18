using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSIMS
{
    class DatabaseAdmin
    {
        /*
        SqlConnection conn;

        public DatabaseAdmin()
        {
            conn = new SqlConnection(@"Data Source=andrei-greg.database.windows.net;Initial Catalog=InventoryDB;Persist Security Info=True;User ID=DBadmin;Password=JohnIsGreat2000");
            conn.Open();
        }

        public List<UserLogIn> GetAllUsers()
        {
            List<UserLogIn> result = new List<UserLogIn>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Users", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int userid = (int)reader["UserId"];
                    string userName = (string)reader["Username"];
                    string password = (string)reader["Password"];
                    string role = (string)reader["Role"];
                    UserLogIn u = new UserLogIn(userid, userName, password, role);
                    result.Add(u);
                }
            }
            return result;
        }
        */
    }
}
