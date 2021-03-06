﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model.DAO;
using Model.DTO;
using Model.Entity;
using Model.Service;

namespace Model.Converter
{
    public interface Converter<A, B>
    {
        B convert(A o);
    }

    public class ObservableCollectionPlayerMapper : Converter<List<PlayerDto>, ObservableCollection<PlayerDto>>
    {
        public ObservableCollection<PlayerDto> convert(List<PlayerDto> o)
        {
            throw new NotImplementedException();
        }
    }

    public class UserConverter : Converter<User, UserDto>, Converter<UserDto, User>
    {
        public UserDto convert(User user)
        {
            //Player activePlayer = 
            UserDto userDto = new UserDto(user.Id, user.Login, user.Password, new Player(0,0,""));
            return userDto;
        }

        public User convert(UserDto userDto)
        {
            User user = new User(userDto);
            return user;
        }
    }

    public class PlayerConverter : Converter<Player, PlayerDto>, Converter<PlayerDto, Player>
    {
        public PlayerDto convert(Player player)
        {
            PlayerDto playerDto = new PlayerDto(player.Id, player.UserId, player.Nick);
            return playerDto;
        }

        public Player convert(PlayerDto playerDto)
        {
            Player player = new Player(playerDto.Id, playerDto.UserId, playerDto.Nick);
            return player;
        }
    }

    public class FactionConverter : Converter<Faction, FactionDto>, Converter<FactionDto, Faction>
    {
        public FactionDto convert(Faction faction)
        {
            FactionDto factionDto = new FactionDto(
                faction.Id, 
                faction.HouseId,
                faction.Name,
                faction.Owner,
                faction.Officer1,
                faction.Officer2,
                faction.Officer3,
                faction.Officer4,
                faction.Officer5,
                faction.OfficerChat,
                faction.BasicChat
                );
            return factionDto;
        }

        public Faction convert(FactionDto factionDto)
        {
            Faction faction = new Faction(
                factionDto.Id,
                factionDto.HouseId,
                factionDto.Name,
                factionDto.Owner,
                factionDto.officer1,
                factionDto.officer2,
                factionDto.officer3,
                factionDto.officer4,
                factionDto.officer5,
                factionDto.officerChat,
                factionDto.basicChat
                );
            return faction;
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