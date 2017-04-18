namespace MainSIMS
{
    public class UserLogIn
    {
        private string password;
        private string role;
        private int userid;
        private string userName;

        public UserLogIn(int userid, string userName, string password, string role)
        {
            UserId = userid;
            Username = userName;
            Password = password;
            Role = role;
        }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}