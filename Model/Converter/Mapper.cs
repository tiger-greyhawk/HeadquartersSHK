using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model.DAO;
using Model.DTO;
using Model.Entity;
using Model.Service;

namespace Model.Converter
{
    public interface Mapper<A, B>
    {
        B convert(A o);
    }

    public class ObservableCollectionPlayerMapper : Mapper<List<PlayerDto>, ObservableCollection<PlayerDto>>
    {
        public ObservableCollection<PlayerDto> convert(List<PlayerDto> o)
        {
            throw new NotImplementedException();
        }
    }

    public class PlayerMapper : Mapper<Player, PlayerDto>, Mapper<PlayerDto, Player>
    {
        public PlayerDto convert(Player o)
        {
            throw new NotImplementedException();
        }

        public Player convert(PlayerDto o)
        {
            throw new NotImplementedException();
        }
    }

    public class Mapper
    {
        //private PlayerDao _playerDao;

        /*public Mapper(PlayerDao playerDao)
        {
            _playerDao = playerDao;
        }*/

        public PlayerDto Map(Player player)
        {
            PlayerDto playerDto = new PlayerDto(player.Id, player.UserId, player.Nick);
            return playerDto;
        }

        public ObservableCollection<PlayerDto> Map(IEnumerable<Player> players)
        {
            ObservableCollection<PlayerDto> result = new ObservableCollection<PlayerDto>();
            foreach (Player player in players)
            {
                result.Add(Map(player));
            }
            return result;
        }

        public FactionDto Map(Faction faction)
        {
            FactionDto factionDto = new FactionDto(faction);
            return factionDto;
        }

        public ObservableCollection<FactionDto> Map(IEnumerable<Faction> factions)
        {
            ObservableCollection<FactionDto> result = new ObservableCollection<FactionDto>();
            foreach (Faction faction in factions)
            {
                result.Add(Map(faction));
            }
            return result;
        }
    }
}