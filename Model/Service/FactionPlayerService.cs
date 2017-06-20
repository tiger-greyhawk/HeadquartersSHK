using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Model.DAO;
using Model.DTO;
using Model.Entity;

namespace Model.Service
{
    public interface IFactionPlayerService
    {
        List<FactionPlayer> GetAll();
        List<FactionPlayer> FindByFactionId(int factionId);
        Dictionary<int, List<FactionPlayer>> FindByFactionId(List<int> factionIds);

        FactionPlayer FindByPlayerId(int playerId);
    }

    public class FactionPlayerService : IFactionPlayerService
    {
        private readonly IFactionPlayerDao _factionPlayerDao;
        private IEnumerable<FactionPlayer> _factionPlayers;

        public FactionPlayerService(IFactionPlayerDao factionPlayerDao)
        {
            _factionPlayerDao = factionPlayerDao;
            _factionPlayers = new List<FactionPlayer>();
        }

        public List<FactionPlayer> GetAll()
        {
            _factionPlayers = _factionPlayerDao.GetAll();
            return _factionPlayers.ToList();
        }

        public List<FactionPlayer> FindByFactionId(int factionId)
        {
            //return _factionPlayerDao.GetByFactionId(factionId);
            return _factionPlayers.Where(fp => fp.FactionId == factionId).ToList();
        }

        public Dictionary<int, List<FactionPlayer>> FindByFactionId(List<int> factionIds)
        {
            Dictionary<int, List<FactionPlayer>> result = new Dictionary<int, List<FactionPlayer>>();
            foreach (int factionId in factionIds)
            {
                
                result.Add(factionId, FindByFactionId(factionId));
            }
            return result;
        }

        public FactionPlayer FindByPlayerId(int playerId)
        {
            return _factionPlayers.FirstOrDefault(fp => fp.PlayerId == playerId);
        }

    }
}