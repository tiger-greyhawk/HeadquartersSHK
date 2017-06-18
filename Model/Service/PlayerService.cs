using System;
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

        public PlayerService(PlayerDao playerDao)
        {
            _playerDao = playerDao;
        }

        public List<Player> FindAllPlayers()
        {
            return _playerDao.FindAll();
        }

    }
}