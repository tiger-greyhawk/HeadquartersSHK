using System;
using System.Collections.Generic;
using System.Windows.Documents;
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
        private readonly Model.Converter.Converter<Player, PlayerDto> _playerConverter;

        public PlayerVmFacade(IFactionPlayerService fps, IFactionService fs, IPlayerService ps, Model.Converter.Converter<Player, PlayerDto> playerConverter)
        {
            _factionPlayerService = fps;
            _factionService = fs;
            _playerService = ps;
            _playerConverter = playerConverter;
        }

        public List<PlayerDto> FindPlayers()
        {
            
            List<PlayerDto> result = new List<PlayerDto>();
            //List<FactionPlayer> collection = _factionPlayerService.GetAll();
            List<Player> players = _playerService.GetAllPlayers();
            foreach (Player player in players)
            {
                PlayerDto playerDto = _playerConverter.convert(_playerService.FindById(player.Id));
                try
                {
                    FactionPlayer factionPlayer = _factionPlayerService.FindByPlayerId(player.Id);
                    playerDto.Faction = _factionService.FindFactionById(factionPlayer.FactionId);
                }
                ///TODO переделать catch ошибки на конкретную
                catch (Exception e)
                {
                    playerDto.Faction = null;
                }
                
                
                result.Add(playerDto);
            }
            return result;
        }
    }
}