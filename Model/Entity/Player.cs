using System.Runtime.Serialization;

namespace Model.Entity
{
    [DataContract]
    public class Player
    {
        private int _id;
        private int _userId;
        private string _nick;

        public Player()
        {
        }

        public Player(int id, int userId, string nick)
        {
            _id = id;
            _userId = userId;
            _nick = nick;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Nick
        {
            get { return _nick; }
            set { _nick = value; }
        }
    }
}