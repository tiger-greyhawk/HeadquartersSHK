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

        public PlayerService(PlayerDao playerDao, Mapper mapper)
        {
            _playerDao = playerDao;
            _mapper = mapper;
        }

        public ObservableCollection<PlayerDto> GetPlayers()
        {
            return _players;
        }

        public void UpdatePlayers()
        {
            
            _players = _mapper.Map(_playerDao.GetPlayers());
        }
    }
}