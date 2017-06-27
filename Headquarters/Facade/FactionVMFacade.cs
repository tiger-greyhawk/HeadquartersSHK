using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Converter;
using Model.DTO;
using Model.Entity;
using Model.Service;

namespace Headquarters.Facade
{
    public interface IFactionVmFacade
    {
        FactionDto FindById(int id);
        List<PlayerDto> FindPlayersInFaction(int factionId);
        List<FactionDto> FindFactions();
    }
    public class FactionVmFacade : IFactionVmFacade
    {
        private readonly IFactionPlayerService _factionPlayerService;
        private readonly IFactionService _factionService;
        private readonly IPlayerService _playerService;
        private readonly Model.Converter.Converter<Faction, FactionDto> _factionConverter;
        private readonly Model.Converter.Converter<Player, PlayerDto> _playerConverter;

        public FactionVmFacade(IFactionPlayerService fps, IFactionService fs, IPlayerService ps)//, Model.Converter.Converter<Faction, FactionDto> factionConverter)
        {
            _factionPlayerService = fps;
            _factionService = fs;
            _playerService = ps;
            //_factionConverter = factionConverter;
            _factionConverter = new FactionConverter();
            _playerConverter = new PlayerConverter();
        }

        public FactionDto FindById(int id)
        {
            return _factionConverter.convert(_factionService.FindById(id));
        }

        public List<FactionDto> FindFactions()
        {
            List<FactionDto> result = new List<FactionDto>();
            //List<FactionPlayer> collection = _factionPlayerService.GetAll();
            List<Faction> factions = _factionService.GetAllFactions();
            foreach (Faction faction in factions)
            {
                FactionDto factionDto = _factionConverter.convert(_factionService.FindById(faction.Id));
                result.Add(factionDto);
            }
            return result;
        }

        public List<PlayerDto> FindPlayersInFaction(int factionId)
        {
            //PlayerConverter converter = new PlayerConverter();
            List<PlayerDto> result = new List<PlayerDto>();
            List<FactionPlayer> collection = _factionPlayerService.FindByFactionId(factionId);
            foreach (FactionPlayer factionPlayer in collection)
            {
                PlayerDto playerDto = _playerConverter.convert(_playerService.FindById(factionPlayer.PlayerId));
                playerDto.Faction = _factionService.FindById(factionPlayer.FactionId);
                result.Add(playerDto);
            }
            return result;
        }

        
    }
}
