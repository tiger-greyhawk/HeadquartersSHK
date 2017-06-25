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
        List<PlayerDto> FindPlayersInFaction(int factionId);
    }
    public class FactionVmFacade
    {
        private readonly IFactionPlayerService _factionPlayerService;
        private readonly IFactionService _factionService;
        private readonly IPlayerService _playerService;
        private readonly Model.Converter.Converter<Player, PlayerDto> _playerConverter;

        public FactionVmFacade(IFactionPlayerService fps, IFactionService fs, IPlayerService ps, Model.Converter.Converter<Player, PlayerDto> playerConverter)
        {
            _factionPlayerService = fps;
            _factionService = fs;
            _playerService = ps;
            _playerConverter = playerConverter;
        }

        public List<PlayerDto> FindPlayersInFaction(int factionId)
        {
            //PlayerConverter converter = new PlayerConverter();
            List<PlayerDto> result = new List<PlayerDto>();
            List<FactionPlayer> collection = _factionPlayerService.FindByFactionId(factionId);
            foreach (FactionPlayer factionPlayer in collection)
            {
                PlayerDto playerDto = _playerConverter.convert(_playerService.FindById(factionPlayer.PlayerId));
                playerDto.Faction = _factionService.FindFactionById(factionPlayer.FactionId);
                result.Add(playerDto);
            }
            return result;
        }

        
    }
}
