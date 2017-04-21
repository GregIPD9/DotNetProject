using MainSIMS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
    /// <summary>
    /// Interaction logic for SupplierView.xaml
    /// </summary>
    public partial class SupplierView : Window
    {
        Database db;
        // internal static object xaml;

        public SupplierView()
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

        private void TbFilter_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            {
                string filter = tbFilter.Text.ToLower();
                if (filter == "")
                {
                    lvProductList.ItemsSource = db.GetAllProducts();
                }
                else
                {         
                    List<Product> list = db.GetAllProducts();

                      var filteredList = from p in list
                                         where p.ProductName.ToLower().Contains(filter) ||
                                               p.Location.ToLower().Contains(filter) ||
                                               p.SupplierName.ToLower().Contains(filter)||  
                                               p.Category.ToLower().Contains(filter)||
                                               p.ProductId.ToString().Contains(filter) ||
                                               p.Price.ToString().Contains(filter) ||
                                               p.Quantity.ToString().Contains(filter) ||
                                               p.SCU.ToString().Contains(filter)
                                               select p;

                            lvProductList.ItemsSource = filteredList;
                 }
              }
          }
        

        private void buttonSignOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have been successfully signed out.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
