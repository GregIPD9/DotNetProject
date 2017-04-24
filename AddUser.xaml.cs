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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        InventoryDBEntitiesFK db;

        public AddUser()
        {
            InitializeComponent();
            db = new InventoryDBEntitiesFK();
            // missing something

        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            User user1 = new User();
            user1.EmployeeName = tbUserNameUser.Text;
            user1.Password = tbPasswordUser.Text;
            user1.Role = comboBoxRoleUser.Text;
            try
            {
                db.Users.Add(user1);
                db.SaveChanges();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
