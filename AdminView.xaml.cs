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

namespace MainSIMS
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        Database db;
        public AdminView()
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
    }
}
