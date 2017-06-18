using System.Collections.Generic;
using Model.DTO;
using System.Collections.ObjectModel;
using Model.Converter;
using Model.Entity;
using Model.Service;


namespace Headquarters.VM
{
    public class PlayerViewModel
    {
        public ObservableCollection<PlayerDto> Players { get; }
        private PlayerService _playerService;

        public PlayerViewModel(PlayerService playerService)
        {
            _playerService = playerService;
            Players = Collect(_playerService.FindAllPlayers());
        }

        private ObservableCollection<PlayerDto> Collect(List<Player> players)
        {
            PlayerMapper mapper = new PlayerMapper();
            ObservableCollection<PlayerDto> result = new ObservableCollection<PlayerDto>();
            foreach (Player player in players)
            {
                result.Add(mapper.convert(player));
            }
            return result;
        }
    }
}