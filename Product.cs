using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainSIMS
{
    class Product
    {
        public Product(int id, string scu, string productName, decimal price, int quantity, string location, string category, string supplierName)
        {
                    ProductId = id;
                    Scu = scu;
                    ProductName = productName;
                    Price = price;
                    Quantity = quantity;
                    Location = location;
                    CategoryName = category;
                    SupplierName = supplierName; 
        }
        public int ProductId { get; set; }
        public string Scu;
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Location;
        public decimal Price;
        public string CategoryName;
        public string SupplierName;

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", ProductId, Scu, ProductName, Price, Quantity, Location, CategoryName, SupplierName);
        }
    }
}
