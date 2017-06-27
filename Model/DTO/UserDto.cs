using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Entity;

namespace Model.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Player ActivePlayer { get; set; }

        /*public PlayerDto()
        {
            Id = 0;
            UserId = 0;
            Nick = "";
        }*/

        public UserDto(int id, string login, string password, Player activePlayer)
        {
            Id = id;
            Login = login;
            Password = password;
            ActivePlayer = activePlayer;
        }

        /***
         * Не делает активПлеера. Надо делать не так и не здесь? В фасаде или ВьюМоделе
         */
        /*
        public UserDto(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
        }*/

        
    }
}
