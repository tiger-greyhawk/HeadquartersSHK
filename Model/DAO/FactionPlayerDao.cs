using System;
using System.Collections.Generic;
using System.Linq;
using Model.Converter;
using Model.DTO;
using Model.Entity;
using Model.REST;

namespace Model.DAO
{
    public interface IFactionPlayerDao
    {
        List<FactionPlayer> GetAll();
        
        /**
         * Recieves faction id, returns list of player ids in that faction.
         */
            List<FactionPlayer> GetByFactionId(int factionId);

        /**
         * Recieves a list of faction ids, returns a map of faction id to lists of player ids for that factions.
         */
        Dictionary<int, List<FactionPlayer>> FindByFactionIds(List<int> factionIds);

        //FactionPlayer GetByPlayerId(int playerId);
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

        public List<FactionPlayer> GetAll()
        {
            return _converterJson.ConvertJsonToFactionPlayers(_restClient.DoGet("faction-player/all/")).ToList();
        }

        public List<FactionPlayer> GetByFactionId(int factionId)
        {
            return _converterJson.ConvertJsonToFactionPlayers(_restClient.DoGet("faction-player/"+factionId)).ToList();
        }

        public Dictionary<int, List<FactionPlayer>> FindByFactionIds(List<int> factionIds)
        {
            throw new NotImplementedException();
        }
    }
}