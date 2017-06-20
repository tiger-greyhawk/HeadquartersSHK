using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model.Converter;
using Model.DAO;
using Model.DTO;
using Model.Entity;

namespace Model.Service
{
    public interface IFactionService
    {
        List<Faction> GetAllFactions();
        Faction FindFactionById(int factionId);
    }

    public class FactionService: IFactionService
    {
        private IEnumerable<Faction> _factions;
        private readonly IFactionDao _factionDao;

        public FactionService(IFactionDao factionDao)
        {
            _factionDao = factionDao;
            _factions = new List<Faction>();
        }

        public List<Faction> GetAllFactions()
        {
            _factions = _factionDao.GetAll();
            return _factions.ToList();
        }

        public Faction FindFactionById(int factionId)
        {
            return _factions.FirstOrDefault(f => f.Id == factionId);
        }
    }
}