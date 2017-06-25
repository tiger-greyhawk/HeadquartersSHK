using System.Runtime.Serialization;

namespace Model.Entity
{
    [DataContract]
    public class User
    {
        [DataMember] private int _id;
        [DataMember] private string _login;
        [DataMember] private string _password;

        public User()
        {
        }

        public User(int id, string login, string password)
        {
            _id = id;
            _login = login;
            _password = password;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}