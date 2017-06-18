using System;
using System.Collections.Generic;
using Model.Converter;
using Model.DTO;
using Model.Entity;
using Model.REST;

namespace Model.DAO
{
    public interface IFactionPlayerDao
    {
        /**
         * Recieves faction id, returns list of player ids in that faction.
         */
        List<FactionPlayer> FindByFactionId(int factionId);

        /**
         * Recieves a list of faction ids, returns a map of faction id to lists of player ids for that factions.
         */
        Dictionary<FactionPlayer, List<FactionPlayer>> FindByFactionIds(List<int> factionIds);
    }

    public class FactionPlayerDao : IFactionPlayerDao
    {
        private readonly RestClient _restClient;
        private readonly ConverterJson _converterJson;
        
        public FactionPlayerDao(RestClient restClient, ConverterJson converterJson)
        {
            _restClient = restClient;
            _converterJson = converterJson;
            
        }

        public List<FactionPlayer> FindByFactionId(int factionId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<FactionPlayer>> FindByFactionIds(List<int> factionIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FactionPlayer> GetFactionPlayers()
        {
            return _converterJson.ConvertJsonToFactionPlayers(_restClient.DoGet("faction-player/all/"));
        }
    }
}