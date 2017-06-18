using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model.Converter;
using Model.DAO;
using Model.DTO;
using Model.Entity;

namespace Model.Service
{
    public class FactionService
    {
        private readonly FactionDao _factionDao;

        public FactionService(FactionDao factionDao)
        {
            _factionDao = factionDao;
        }

        public List<Faction> FindAllFactions()
        {
            return _factionDao.FindAll();
        }

    }
}