using System.Collections;
using System.Collections.Generic;
using Model.Entity;
using Model.REST;

namespace Model.DAO
{
    public class PlayerDao
    {
        private IEnumerable<Player> _players;
        private RestClient _restClient;

        public PlayerDao(RestClient restClient)
        {
            _restClient = restClient;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _restClient.GetPlayers();
        }
    }
}