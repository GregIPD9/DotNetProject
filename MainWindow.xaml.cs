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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MainSIMS;

namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(tbUser.Text))
            {
                MessageBox.Show("Please enter your username.", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbUser.Focus();
                return;
            }
            try
            {
               using (InventoryDBEntities login = new InventoryDBEntities())
                {
                    var query = from user in login.Users
                                where user.Username == tbUser.Text && user.Password == tbPassword.Text && user.Role == ComboBoxRole.Text                           
                                select user;
                  

                    if (query.SingleOrDefault() != null)
                    {
                        switch (ComboBoxRole.Text)
                        {
                            case "Admin":
                               AdminView admin = new AdminView();
                               admin.Show();
                               break;
                            case "Manager":
                               ManagerView manager = new ManagerView();
                               manager.Show();
                               break;
                            case "Employee":
                               EmployeeView empl = new EmployeeView();
                               empl.Show();
                               break;
                            case "Supplier":
                               SupplierView supplier = new SupplierView();
                               supplier.Show();
                               break;
                        }
                 // Just for testing purpose, I'll keep this message here for now
                        MessageBox.Show("You have been successfully logged in.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);  
                    }
                    else
                    {
                        MessageBox.Show("Your username or password is incorrect.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }       
    }
}
