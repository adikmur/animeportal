namespace AnimePortal
{
    public class User
    {
        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
