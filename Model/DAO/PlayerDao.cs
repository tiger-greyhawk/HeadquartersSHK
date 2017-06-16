using System.Collections;
using System.Collections.Generic;
using Model.Converter;
using Model.Entity;
using Model.REST;
using Model.Setting;

namespace Model.DAO
{
    public class PlayerDao
    {
        //private IEnumerable<Player> _players;
        private readonly RestClient _restClient;
        private readonly ConverterJson _converterJson;


        public PlayerDao(RestClient restClient)
        {
            _restClient = restClient;
            _converterJson = new ConverterJson();
            //_players = new List<Player>();
        }

        public IEnumerable<Player> GetPlayers()
        {
            //return _players;
            return _converterJson.ConvertJsonToPlayers(_restClient.DoGet("player/"));
        }

        /*public void UpdatePlayers()
        {
            _players = _converterJson.ConvertJsonToPlayers(_restClient.DoGet("player/"));
        }*/
    }
}