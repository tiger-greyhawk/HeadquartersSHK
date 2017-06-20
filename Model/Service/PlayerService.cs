using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model.Converter;
using Model.DAO;
using Model.DTO;
using Model.Entity;

namespace Model.Service
{

    public interface IPlayerService : IService
    {
        List<Player> GetAllPlayers();
        Player FindById(int playerId);
    }

    public class PlayerService : IPlayerService
    {
        private readonly IPlayerDao _playerDao;
        private IEnumerable<Player> _players;

        public PlayerService(IPlayerDao playerDao)
        {
            _playerDao = playerDao;
            _players = new List<Player>();
        }

        public List<Player> GetAllPlayers()
        {
            _players = _playerDao.GetAll();
            return _players.ToList();
        }

        public Player FindById(int playerId)
        {
            return _players.FirstOrDefault(p => p.Id == playerId);
        }

    }
}