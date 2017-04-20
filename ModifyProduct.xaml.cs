using InventoryApp;
using System;
using System.Collections.Generic;
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

namespace MainSIMS
{
    /// <summary>
    /// Interaction logic for ModifyProduct.xaml
    /// </summary>
    public partial class ModifyProduct : Window
    {
        ManagerView man = new ManagerView();
        InventoryDBEntities db;

        public ModifyProduct()
        {
            InitializeComponent();
            db = new InventoryDBEntities();

        }

        private void btnSaveChangesProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (InventoryDBEntities ctx = new InventoryDBEntities())
                {
                    Product p = ctx.Products.Find(Convert.ToInt32(lblProductIdEdit.Content));
                    p.ProductName = tbProductNameEdit.Text;
                    p.Category = tbCategoryEdit.Text;
                    p.Descrition = tbDescriptionEdit.Text;
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
