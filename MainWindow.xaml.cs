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
            SqlConnection cn = new SqlConnection("Server=tcp:andrei-greg.database.windows.net,1433;Initial Catalog=InventoryDB;Persist Security Info=False;User ID={DBadmin};Password={JohnIsGreat2000};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.users WHERE user = '"+ tbUser.Text + "' AND password = '"+tbPassword.Text + "'", cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            if (count == 1)
            {
                MessageBox.Show("ok");
                MainSIMS.AdminView adminView = new MainSIMS.AdminView();
                adminView.Show();
            }
            else if (count > 0)
            {
                MessageBox.Show("Duplicate username and password");
            }
            else
            {
                MessageBox.Show("username or password not correct");
            }
            tbUser.Clear();
            tbPassword.Clear();



            // ManagerView managerView = new ManagerView();
            //  managerView.Show();
        }       
    }
}
