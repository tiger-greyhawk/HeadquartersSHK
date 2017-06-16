using Model.DTO;
using System.Collections.ObjectModel;
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
            Players = _playerService.Players;
        }
    }
}