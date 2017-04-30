using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MainSIMS
{
    /// <summary>
    /// Interaction logic for ViewPO.xaml
    /// </summary>
    public partial class ViewPO : Window
    {
        Database db;
        int selectedProductIndex;
        int selectedOrderProductIndex;
        List<Product> newOrder = new List<Product>();
        List<Product> list = new List<Product>();
      
        public ViewPO()   
        {
            db = new Database();
            InitializeComponent();
            lvNewOrderList.ItemsSource = newOrder;
        }
        private void TbFilter_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = tbFilter.Text.ToLower();
            if (filter == "")
            {
                lvOrdersList.ItemsSource = db.GetAllProducts();
            }
            else
            {
                list = db.GetAllProducts();

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
                lvOrdersList.ItemsSource = filteredList;
            }
        }
        private void lvOrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProductIndex = lvOrdersList.SelectedIndex;
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {     
            decimal priceQty=0;
            newOrder.Add(list.ElementAt(selectedProductIndex));
            lvNewOrderList.Items.Refresh();
            foreach(Product p in newOrder){
                priceQty+=p.Price*p.Quantity;
            }
            tbTotalCost.Text = priceQty.ToString("0.##");
        }

        private void btnEditProductInPO_Click(object sender, RoutedEventArgs e)
        {
            OrderPOModifyQuantity ord = new OrderPOModifyQuantity();
            Product p = (Product)lvNewOrderList.Items.GetItemAt(selectedOrderProductIndex);
            ord.lblProductId.Content = p.ProductId;
            ord.lblProductName.Content = p.ProductName;
            ord.tbQuantityToOrder.Text = p.Quantity.ToString();
            ord.ShowDialog();
            lvNewOrderList.Items.Refresh();
        }

        private void btnDeleteFromPO_Click(object sender, RoutedEventArgs e)
        {
            selectedOrderProductIndex = lvNewOrderList.SelectedIndex;
            newOrder.Remove(newOrder.ElementAt(selectedOrderProductIndex));
            lvNewOrderList.Items.Refresh();
                  
        }

        private void btPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(lvNewOrderList, "Print List");
            }
        }


    }
}
  
