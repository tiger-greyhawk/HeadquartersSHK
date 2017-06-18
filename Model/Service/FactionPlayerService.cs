using System.Collections.Generic;
using System.Linq;
using Model.DAO;
using Model.DTO;
using Model.Entity;

namespace Model.Service
{
    public class FactionPlayerService
    {
        private readonly FactionPlayerDao _factionPlayerDao;

        public FactionPlayerService(FactionPlayerDao factionPlayerDao)
        {
            _factionPlayerDao = factionPlayerDao;
        }

        public List<FactionPlayer> FindByFactionId(int factionId)
        {
            return _factionPlayerDao.FindByFactionId(factionId);
            _factionPlayerDao.
        }

        public Dictionary<FactionPlayer, List<FactionPlayer>> FindByFactionId(List<int> factionId)
        {

        }

    }
}