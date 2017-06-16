using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model.Converter;
using Model.DAO;
using Model.DTO;
using Model.Entity;

namespace Model.Service
{
    public class PlayerService
    {
        private readonly PlayerDao _playerDao;
        private ObservableCollection<PlayerDto> _players;
        private readonly Mapper _mapper;
        private readonly FactionPlayerService _factionPlayerService;

        public PlayerService(PlayerDao playerDao, Mapper mapper)
        {
            _playerDao = playerDao;
            _mapper = mapper;
            _players = new ObservableCollection<PlayerDto>();
            _factionPlayerService = new FactionPlayerService();
        }

        public ObservableCollection<PlayerDto> Players
        {
            get
            {
                return _players;
            }
        }

        public void UpdatePlayers()
        {
            
            _players = _mapper.Map(_playerDao.GetPlayers());
            for (int i=0; i < _players.Count; i++)
            {
                //PlayerDto player
                _players[i] = _factionPlayerService.FillPlayer(_players[i]);
            }
        }
    }
}