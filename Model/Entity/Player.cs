using System.Runtime.Serialization;

namespace Model.Entity
{
    [DataContract]
    public class Player
    {
        [DataMember] private int id;
        [DataMember] private int userId;
        [DataMember] private string nick;



        public Player(int id, int userId, string nick)
        {
            id = id;
            userId = userId;
            nick = nick;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }
    }
}