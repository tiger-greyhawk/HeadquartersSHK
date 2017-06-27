using System.Collections.Generic;
using System.Collections.ObjectModel;
using Headquarters.Facade;
using Model.DTO;

namespace Headquarters.VM
{
    public interface IFactionViewModel
    {
        
    }

    public class FactionViewModel : BaseMagic, IFactionViewModel
    {
        public ObservableCollection<FactionDto> Factions { get; }
        public ObservableCollection<PlayerDto> PlayerDtos { get; set; }
        //private readonly IPlayerService _playerService;
        private readonly IFactionVmFacade _factionVmFacade;

        public FactionViewModel(IFactionVmFacade factionVmFacade)
        {
            _factionVmFacade = factionVmFacade;   
            Factions = Collect(_factionVmFacade.FindFactions());
            //Players = Collect(_playerService.GetAllPlayers());
        }

        private ObservableCollection<FactionDto> Collect(List<FactionDto> factionDtos)
        {
            ObservableCollection<FactionDto> result = new ObservableCollection<FactionDto>();
            foreach (FactionDto factionDto in factionDtos)
            {
                result.Add(factionDto);
            }
            return result;
        }

        private ObservableCollection<PlayerDto> Collect(List<PlayerDto> playerDtos)
        {
            ObservableCollection<PlayerDto> result = new ObservableCollection<PlayerDto>();
            foreach (PlayerDto playerDto in playerDtos)
            {
                playerDto.Avatar = "c:\\src\\Headquarters\\View\\Media\\Icon\\connect.png";
                result.Add(playerDto);
            }
            return result;
        }

        public int? SelectedValue
        {
            set
            {
                if (value == null)
                    return;
                FactionDto factionDto =  _factionVmFacade.FindById((int)value);
                if (SelectedFaction == null)
                {
                    SelectedFaction
                        = new FactionDto(factionDto);
                }
                else
                {
                    SelectedFaction = factionDto;
                    //SelectedFaction.Update(factionDto);
                }
            }
        }

        private FactionDto _selectedFaction;
        public FactionDto SelectedFaction
        {
            get { return _selectedFaction; }
            set
            {
                if (value == null)
                {
                    _selectedFaction = value;
                }
                else
                {
                    if (_selectedFaction == null)
                    {
                        _selectedFaction =
                            new FactionDto(value);
                    }
                    _selectedFaction = value;
                    //_selectedFaction.Update(value);
                }
                if (_selectedFaction != null)
                    PlayerDtos = Collect(_factionVmFacade.FindPlayersInFaction(_selectedFaction.Id));
                else
                {
                    PlayerDtos = new ObservableCollection<PlayerDto>();
                }
                //UpdatePlayersInFaction();
                //RaisePropertyChanged(nameof(DeleteButtonEnabled));
            }
        }
    }
}