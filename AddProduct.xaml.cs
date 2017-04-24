using System;
using System.Windows;

namespace MainSIMS
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        InventoryDBEntitiesFK db;

        public AddProduct()
        {
            InitializeComponent();
            db = new InventoryDBEntitiesFK();
        }

        private void btnAddProductToInventory_Click(object sender, RoutedEventArgs e)
        {
            Product product1 = new Product();
            product1.ProductName = tbProductName.Text;
            product1.Category = tbCategory.Text;
            product1.Description = tbDescription.Text;
            product1.Price = Convert.ToDecimal(this.tbPrice.Text);
            product1.SCU = Convert.ToInt32(this.tbSCU.Text);
            product1.Quantity = Convert.ToInt32(this.tbQuantity.Text);
            product1.Location = tbLocation.Text;
            product1.SupplierName = tbSupplier.Text;

            try
            {
                db.Products.Add(product1);
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
