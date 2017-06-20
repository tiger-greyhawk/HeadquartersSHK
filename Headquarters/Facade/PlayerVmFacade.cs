using System.Collections.Generic;
using System.Windows.Documents;
using Model.Converter;
using Model.DTO;
using Model.Entity;
using Model.Service;

namespace Headquarters.Facade
{
    public interface IPlayerVmFacade
    {
        List<PlayerDto> FindPlayers();
    }

    public class PlayerVmFacade : IPlayerVmFacade
    {
        private readonly IFactionPlayerService _factionPlayerService;
        private readonly IFactionService _factionService;
        private readonly IPlayerService _playerService;

        public PlayerVmFacade(IFactionPlayerService fps, IFactionService fs, IPlayerService ps)
        {
            _factionPlayerService = fps;
            _factionService = fs;
            _playerService = ps;
        }

        public List<PlayerDto> FindPlayers()
        {
            PlayerConverter converter = new PlayerConverter();
            List<PlayerDto> result = new List<PlayerDto>();
            List<FactionPlayer> collection = _factionPlayerService.GetAll();
            List<Player> players = _playerService.GetAllPlayers();
            foreach (Player player in players)
            {
                PlayerDto playerDto = converter.convert(_playerService.FindById(player.Id));
                FactionPlayer factionPlayer = _factionPlayerService.FindByPlayerId(player.Id);
                playerDto.Faction = _factionService.FindFactionById(factionPlayer.FactionId);
                //players.Add(playerDto);
            }
            return result;
        }
    }
}