using System.Collections.Generic;
using System.IO;

namespace AnimePortal
{
    public class Authorization
    {
        private const string _file = "../../Data/users.txt";
        private List<User> _users = new List<User>();

        public Authorization()
        {
            using (StreamReader sr = new StreamReader(_file))
            {
                while (!sr.EndOfStream)
                {
                    var lineParts = sr.ReadLine().Split('|');
                    if (lineParts.Length == 2)
                    {
                        _users.Add(new User(lineParts[0], lineParts[1]));
                    }
                }
            }
        }

        public bool CheckUser(string login, string password)
        {
            foreach (User user in _users)
            {
                if (login == user.Login && password == user.Password)
                {
                    Logger.Log($"Пользователь {login} зашел в систему.");
                    return true;
                }
            }
            return false;
        }
    }
}
