using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSIMS
{
    class Database
    {
        SqlConnection conn;
        private string description;

        public Database()
        {
            conn = new SqlConnection(@"Data Source=andrei-greg.database.windows.net;Initial Catalog=InventoryDB;Persist Security Info=True;User ID=DBadmin;Password=JohnIsGreat2000");
            conn.Open();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> result = new List<Product>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Products", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["ProductId"];
                    int scu = (int)reader["SCU"];
                    string productName = (string)reader["ProductName"];
                    decimal price = (decimal)reader["Price"];
                    int quantity = (int)reader["Quantity"];
                    string location = (string)reader["Location"];
                    string category = (string)reader["Category"];
                    string supplierName = (string)reader["SupplierName"];
                    string descrition = (string)reader["Descrition"];
                    Product p = new Product(id, scu, productName, price, quantity, location, category, supplierName, descrition);
                    result.Add(p);
                }
            }
            return result;
        }

        public List<User> GetAllUsers()
        {
            List<User> result = new List<User>();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Users", conn))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["UserId"];
                    string userName = (string)reader["Username"];
                    string password = (string)reader["Password"];
                    string role = (string)reader["Role"];
                    User u = new User(id, userName, password, role);
                    result.Add(u);
                }
            }
            return result;
        }

        internal void UpdateUser(User u) {

            string sql = "UPDATE users SET Username = @Username, Password = @Password, Role = @Role WHERE UserId=@UserId"; 
            SqlCommand cmd = new SqlCommand(sql, conn); 
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = u.UserId; 
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = u.Username;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = u.Password;
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = u.Role;
            cmd.CommandType = CommandType.Text; cmd.ExecuteNonQuery(); 
        }

    }
}
