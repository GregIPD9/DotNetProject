using System.Windows;

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
          
        }
        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            User user1 = new User();
            user1.EmployeeName = tbUserNameUser.Text;
            user1.Password = tbPasswordUser.Text;
            user1.Role = comboBoxRoleUser.Text;
            user1.insertUser();
            MessageBox.Show("Cogradulations!!! Record inserted");  

            /*   OLD WAY without Stored Procedure
               
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
            */
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
