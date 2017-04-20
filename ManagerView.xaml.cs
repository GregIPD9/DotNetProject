using MainSIMS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventoryApp
{
   
    public partial class ManagerView : Window
    {
        Database db;
       
        public ManagerView()
        {
            try
            {
                db = new Database();
                InitializeComponent();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            lvProductList.ItemsSource = db.GetAllProducts();
        }

        private void btnAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct prod = new AddProduct();
            prod.ShowDialog();
            lvProductList.ItemsSource = db.GetAllProducts();
        }
    }
}
