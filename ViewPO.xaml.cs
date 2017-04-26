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


        public ViewPO()   
        {
            db = new Database();
            InitializeComponent();
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

                lvOrdersList.ItemsSource = filteredList;
            }
        }

        private void lvOrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProductIndex = lvOrdersList.SelectedIndex;
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            selectedProductIndex = lvRealOrderList.SelectedIndex;
        }

       
    }
}
