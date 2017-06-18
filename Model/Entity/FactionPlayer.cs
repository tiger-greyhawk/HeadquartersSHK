using System.Runtime.Serialization;

namespace Model.Entity
{
    [DataContract]
    public class FactionPlayer
    {
        private int id;
        private int playerId;
        private int factionId;

        public FactionPlayer()
        {
            id = 0;
            playerId = 0;
            factionId = 0;
        }

        public FactionPlayer(int id, int playerId, int factionId)
        {
            this.id = id;
            this.playerId = playerId;
            this.factionId = factionId;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
        }

        public int FactionId
        {
            get { return factionId; }
            set { factionId = value; }
        }
    }
}