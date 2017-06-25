using System;
using System.Collections;
using System.Collections.Generic;
using Model.Converter;
using Model.Entity;
using Model.REST;
using Model.Setting;

namespace Model.DAO
{
    public interface IPlayerDao //: IExamplePlayerDao
    {
        List<Player> GetAll();
        List<Player> FindById(int id);
    }

    public class PlayerDao : ExamplePlayerDao, IPlayerDao
    {
        private readonly RestClient _restClient;
        private readonly ConverterJson _converterJson;

        public PlayerDao(RestClient restClient, ConverterJson converterJson) : base(restClient, converterJson)
        {
            _restClient = restClient;
            _converterJson = converterJson;
        }

        /*public PlayerDao(RestClient restClient, ConverterJson converterJson) 
        {
            _restClient = restClient;
            _converterJson = converterJson;
        }*/

        public List<Player> GetAll()
        {
            return new List<Player>(_converterJson.ConvertJsonToPlayers(_restClient.DoGet("player")));
        }

        public List<Player> FindById(int id)
        {
            return new List<Player>(_converterJson.ConvertJsonToPlayers(_restClient.DoGet("player/" + id)));
        }
    }
}