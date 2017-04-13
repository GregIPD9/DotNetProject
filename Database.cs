using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSIMS
{
    class Database
    {
        SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(@"Data Source=andrei-greg.database.windows.net;Initial Catalog=InventoryDB;Persist Security Info=True;User ID=DBadmin;Password=***********");
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
                    string scu = (string)reader["Scu"];
                    string productName = (string)reader["ProductName"];
                    decimal price = (decimal)reader["Price"];
                    int quantity = (int)reader["Quantity"];
                    string location = (string)reader["Location"];
                    string category = (string)reader["CategoryName"];
                    string supplierName = (string)reader["SupplierName"];
                    Product p = new Product(id, scu, productName, price, quantity, location, category, supplierName);
                    result.Add(p);
                }
            }
            return result;
        }

    }
}
