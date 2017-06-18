using Model.Entity;

namespace Model.DTO
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Nick { get; set; }
        public Faction Faction { get; set; }

        /*public PlayerDto()
        {
            Id = 0;
            UserId = 0;
            Nick = "";
        }*/

        public PlayerDto(int id, int userId, string nick)
        {
            Id = id;
            UserId = userId;
            Nick = nick;
        }

        public PlayerDto(Player player)
        {
            Id = player.Id;
            UserId = player.UserId;
            Nick = player.Nick;
        }
    }
}