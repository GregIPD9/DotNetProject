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
using MainSIMS;

namespace MainSIMS
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        Database db;
        int selectedItemIndex;
        public AdminView()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                //refreshUsersList();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
        }

        private void btnViewAllUsers_Click(object sender, RoutedEventArgs e)
        {
            lvUsersList.ItemsSource = db.GetAllUsers();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser win = new AddUser();
            win.ShowDialog();
            // lvUsersList.UpdateLayout();
            lvUsersList.ItemsSource = db.GetAllUsers();
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            // lvUsersList.Items.RemoveAt(lvUsersList.Items.IndexOf(lvUsersList.SelectedItem));
            try
            {
                using (InventoryDBEntitiesFK ctx = new InventoryDBEntitiesFK())
                {
                    User selected = (User) lvUsersList.SelectedItem;
                    User u = ctx.Users.Find(Convert.ToInt32(selected.EmployeeId));
                    ctx.Users.Remove(u);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refreshUsersList();
        }

        private void btnModifyUser_Click(object sender, RoutedEventArgs e)
        {
            ModifyUser win = new ModifyUser();
            User u =(User) lvUsersList.Items.GetItemAt(selectedItemIndex);
            win.lblUserId.Content = u.EmployeeId;
            win.tbUserNameInModify.Text = u.EmployeeName;
            win.tbPasswordInmodify.Text = u.Password;
            win.comboBoxRoleInModify.Text = u.Role;
            win.Show();
        }

        private void lvUsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItemIndex = lvUsersList.SelectedIndex;
        }

        public void refreshUsersList() 
        { 
            lvUsersList.ItemsSource = db.GetAllUsers();
        }

        private void buttonSignOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You have been successfully signed out.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
