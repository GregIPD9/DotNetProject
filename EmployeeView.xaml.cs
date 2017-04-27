using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace MainSIMS
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        Database db;
        public EmployeeView()
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
        private void btloadProducts_Click(object sender, RoutedEventArgs e)
        {
            lvProductList.ItemsSource = db.GetAllProducts();
            lblLoggedInAs.Content = "Name: " + Globals.currentUser.EmployeeName + "  Role: " + Globals.currentUser.Role;               
        }
        private void TbFilter_OnTextChanged(object sender, TextChangedEventArgs e)
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
                                         p.SupplierName.ToLower().Contains(filter) ||
                                         p.Category.ToLower().Contains(filter) ||
                                         p.ProductId.ToString().Contains(filter) ||
                                         p.Price.ToString().Contains(filter) ||
                                         p.Quantity.ToString().Contains(filter) ||
                                         p.SCU.ToString().Contains(filter)
                                   select p;

                lvProductList.ItemsSource = filteredList;
                lblLoggedInAs.Content = "Name: " + Globals.currentUser.EmployeeName + "  Role: " + Globals.currentUser.Role;               

            }
        }

        private void buttonSignOut_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Globals.currentUser.EmployeeName = null;
            Globals.currentUser.Role = null;
            Globals.currentUser.Password = null;
            //Globals.currentUser = null;
            MessageBox.Show("You have been successfully signed out.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
