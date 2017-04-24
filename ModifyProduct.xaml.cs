using InventoryApp;
using System;
using System.Windows;

namespace MainSIMS
{
    /// <summary>
    /// Interaction logic for ModifyProduct.xaml
    /// </summary>
    public partial class ModifyProduct : Window
    {
        ManagerView man = new ManagerView();
        InventoryDBEntitiesFK db;

        public ModifyProduct()
        {
            InitializeComponent();
            db = new InventoryDBEntitiesFK();

        }

        private void btnSaveChangesProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (InventoryDBEntitiesFK ctx = new InventoryDBEntitiesFK())
                {
                    Product p = ctx.Products.Find(Convert.ToInt32(lblProductIdEdit.Content));
                    p.ProductName = tbProductNameEdit.Text;
                    p.Category = tbCategoryEdit.Text;
                    p.Description = tbDescriptionEdit.Text;
                    p.Price = Convert.ToDecimal(this.tbPriceEdit.Text);
                    p.SCU = Convert.ToInt32(this.tbSCUEdit.Text);
                    p.Quantity = Convert.ToInt32(this.tbQuantityEdit.Text);
                    p.Location = tbLocationEdit.Text;
                    p.SupplierName = tbSupplierEdit.Text;
                    ctx.SaveChanges();
                    this.Close();
                    man.refreshProductsList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
