using System.Runtime.Serialization;

namespace Model.Entity
{
    [DataContract]
    public class Player
    {
        private int _id;
        private int _userId;
        private string _nick;

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