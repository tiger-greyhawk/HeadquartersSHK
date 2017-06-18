using System;
using System.Collections.Generic;
using Model.Converter;
using Model.Entity;
using Model.REST;

namespace Model.DAO
{

    public interface IFactionDao
    {
        List<Faction> FindAll();
    }

    public class FactionDao : IFactionDao
    {
        private readonly RestClient _restClient;
        private readonly ConverterJson _converterJson;

        public FactionDao(RestClient restClient, ConverterJson converterJson)
        {
            _restClient = restClient;
            _converterJson = converterJson;
        }

        public List<Faction> FindAll()
        {
            return new List<Faction>(_converterJson.ConvertJsonToFactions(_restClient.DoGet("faction/")));
        }

    }
}