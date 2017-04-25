//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainSIMS
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows;

    public partial class User
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public User(int id, string employeeName, string password, string role)
        {
            EmployeeId = id;
            EmployeeName = employeeName;
            Password = password;
            Role = role;
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        internal void insertUser()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=andrei-greg.database.windows.net;Initial Catalog=InventoryDB;Persist Security Info=True;User ID=DBadmin;Password=JohnIsGreat2000"))
            {
                SqlCommand cmd = new SqlCommand("insertNewUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter newEmployeeName = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);
                SqlParameter newPassword = new SqlParameter("@Password", SqlDbType.VarChar, 50);
                SqlParameter newRole = new SqlParameter("@Role", SqlDbType.VarChar, 50);
                newEmployeeName.Value = EmployeeName;
                newPassword.Value = Password;
                newRole.Value = Role;
                cmd.Parameters.Add(newEmployeeName);
                cmd.Parameters.Add(newPassword);
                cmd.Parameters.Add(newRole);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (Exception)
                {
                    MessageBox.Show("Using Stored Procedure doesn't work! Ha Ha Ha!", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                finally
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
        }
    }
}