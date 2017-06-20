using System.Collections.Generic;
using Model.DTO;
using System.Collections.ObjectModel;
using Headquarters.Facade;
using Model.Converter;
using Model.Entity;
using Model.Service;


namespace Headquarters.VM
{
    public class PlayerViewModel
    {
        public ObservableCollection<PlayerDto> Players { get; }
        //private readonly IPlayerService _playerService;
        private readonly IPlayerVmFacade _playerVmFacade;

        public PlayerViewModel(IPlayerVmFacade playerVmFacade)
        {
            _playerVmFacade = playerVmFacade;
            Players = Collect(_playerVmFacade.FindPlayers());
            //Players = Collect(_playerService.GetAllPlayers());
        }

        private ObservableCollection<PlayerDto> Collect(List<PlayerDto> playerDtos)
        {
            ObservableCollection<PlayerDto> result = new ObservableCollection<PlayerDto>();
            foreach (PlayerDto playerDto in playerDtos)
            {
                result.Add(playerDto);
            }
            return result;
        }
    }
}