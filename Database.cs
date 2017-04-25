using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MainSIMS
{
    class Database
    {
        SqlConnection conn;

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
                    string productName = (string)reader["ProductName"];
                    string category = (string)reader["Category"];
                    string description = (string)reader["Description"];
                    decimal price = (decimal)reader["Price"];
                    int scu = (int)reader["SCU"];
                    int quantity = (int)reader["Quantity"];
                    string location = (string)reader["Location"];
                    string supplierName = (string)reader["SupplierName"];
                    Product p = new Product(id, productName, category, description, price, scu,  quantity, location,  supplierName);
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
                    int id = (int)reader["EmployeeId"];
                    string employeeName = (string)reader["EmployeeName"];
                    string password = (string)reader["Password"];
                    string role = (string)reader["Role"];
                    User u = new User(id, employeeName, password, role);
                    result.Add(u);
                }
            }
            return result;
        }

        internal void UpdateUser(User u) {

            string sql = "UPDATE users SET EmployeeName = @EmployeeName, Password = @Password, Role = @Role WHERE EmployeeId=@EmployeeId"; 
            SqlCommand cmd = new SqlCommand(sql, conn); 
            cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = u.EmployeeId; 
            cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = u.EmployeeName;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = u.Password;
            cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = u.Role;
            cmd.CommandType = CommandType.Text; cmd.ExecuteNonQuery(); 
        }

    }
}
