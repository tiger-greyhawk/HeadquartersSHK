using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Converter;
using Model.DTO;
using Model.Entity;

namespace Model.Service
{
    public interface IFactionVmFacade
    {
        
    }
    public class FactionVmFacade
    {
        private readonly FactionPlayerService _factionPlayerService;
        private readonly IFactionService _factionService;
        private readonly IPlayerService _playerService;

        public FactionVmFacade(FactionPlayerService fps, IFactionService fs, IPlayerService ps)
        {
            _factionPlayerService = fps;
            _factionService = fs;
            _playerService = ps;
        }

        public List<PlayerDto> FindPlayersInFaction(int factionId)
        {
            PlayerConverter converter = new PlayerConverter();
            List<PlayerDto> players = new List<PlayerDto>();
            List<FactionPlayer> collection = _factionPlayerService.FindByFactionId(factionId);
            foreach (FactionPlayer factionPlayer in collection)
            {
                PlayerDto playerDto = converter.convert(_playerService.FindById(factionPlayer.PlayerId));
                playerDto.Faction = _factionService.FindFactionById(factionPlayer.FactionId);
                players.Add(playerDto);
            }
            return players;
        }

        
    }
}
