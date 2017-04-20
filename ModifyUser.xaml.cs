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
using MainSIMS;


namespace MainSIMS
{
    /// <summary>
    /// Interaction logic for ModifyUser.xaml
    /// </summary>
    public partial class ModifyUser : Window
    {
        AdminView win = new AdminView();
        InventoryDBEntities db;

        public ModifyUser()
        {
            InitializeComponent();
          //  db = new Database();
            db = new InventoryDBEntities();
            
            
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                using (InventoryDBEntities ctx = new InventoryDBEntities())
                {
                    User u = ctx.Users.Find(Convert.ToInt32(lblUserId.Content));
                    u.Username = tbUserNameInModify.Text;
                    u.Password = tbPasswordInmodify.Text;
                    u.Role = comboBoxRoleInModify.Text;
                    ctx.SaveChanges();
                    this.Close();
                    win.refreshUsersList();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
            /*

            User u = new User();
            u.UserId = Convert.ToInt32(lblUserId.Content);
            u.Username = tbUserNameInModify.Text;
            u.Password = tbPasswordInmodify.Text;
            u.Role = comboBoxRoleInModify.Text;
            try
            {
                using (InventoryDBEntities ctx = new InventoryDBEntities())
                { 
                ctx.Users.Attach(u); 
                ctx.Users.Remove(u); 
                ctx.SaveChanges();
         }
            //    db.UpdateUser(u);
                //db.SaveChanges();
              //  this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }  
    } 
}
