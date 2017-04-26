using MainSIMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace InventoryApp
{

    public partial class ManagerView : Window
    {
        Database db;
        int selectedProductIndex;

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
            }
        }

        private void btnAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct prod = new AddProduct();
            prod.ShowDialog();
            lvProductList.ItemsSource = db.GetAllProducts();
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (InventoryDBEntitiesFK ctx = new InventoryDBEntitiesFK())
                {
                    Product selected = (Product)lvProductList.SelectedItem;
                    Product p = ctx.Products.Find(Convert.ToInt32(selected.ProductId));
                    ctx.Products.Remove(p);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refreshProductsList();
        }

        public void refreshProductsList()
        {
            lvProductList.ItemsSource = db.GetAllProducts();
        }

        private void btnEditSelectedProduct_Click(object sender, RoutedEventArgs e)
        {
            ModifyProduct mod = new ModifyProduct();
            Product p = (Product)lvProductList.Items.GetItemAt(selectedProductIndex);
            mod.lblProductIdEdit.Content = p.ProductId;
            mod.tbProductNameEdit.Text = p.ProductName;
            mod.tbCategoryEdit.Text = p.Category;
            mod.tbDescriptionEdit.Text = p.Description;
            mod.tbPriceEdit.Text = p.Price.ToString();
            mod.tbSCUEdit.Text = p.SCU.ToString();
            mod.tbQuantityEdit.Text = p.Quantity.ToString();
            mod.tbLocationEdit.Text = p.Location;
            mod.tbSupplierEdit.Text = p.SupplierName;
            mod.Show();

        }

        private void lvProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProductIndex = lvProductList.SelectedIndex;
        }

        private void buttonSignOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have been successfully signed out.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
 
        }

        private void btnViewPO_Click(object sender, RoutedEventArgs e)
        {
            ViewPO po = new ViewPO();
            po.Show();
        }
    }
}
