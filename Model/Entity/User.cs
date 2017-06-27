using System.Runtime.Serialization;
using Model.DTO;

namespace Model.Entity
{
    [DataContract]
    public class User
    {
        [DataMember] private int id;
        [DataMember] private string login;
        [DataMember] private string password;
        [DataMember] private int activePlayerId;

        public User(UserDto userDto)
        {
            id = userDto.Id;
            login = userDto.Login;
            password = userDto.Password;
            activePlayerId = userDto.ActivePlayer.Id;
        }

        public User(int id, string login, string password, int activePlayerId)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.activePlayerId = activePlayerId;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int ActivePlayerId
        {
            get { return activePlayerId; }
            set { activePlayerId = value; }
        }
    }
}