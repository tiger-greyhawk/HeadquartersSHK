﻿using Model.Entity;

namespace Model.DTO
{
    public class FactionDto
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string officer1 { get; set; }
        public string officer2 { get; set; }
        public string officer3 { get; set; }
        public string officer4 { get; set; }
        public string officer5 { get; set; }
        public string officerChat { get; set; }
        public string basicChat { get; set; }

        public FactionDto()
        {
        }

        public FactionDto(Faction faction)
        {
            this.Id = faction.Id;
            this.HouseId = faction.HouseId;
            this.Name = faction.Name;
            this.Owner = faction.Owner;
            /*this.officer1 = faction.officer1;
            this.officer2 = faction.officer2;
            this.officer3 = faction.officer3;
            this.officer4 = faction.officer4;
            this.officer5 = faction.officer5;
            this.officerChat = faction.officerChat;
            this.basicChat = faction.basicChat;*/
        }

        public FactionDto(FactionDto factionDto)
        {
            this.Id = factionDto.Id;
            this.HouseId = factionDto.HouseId;
            this.Name = factionDto.Name;
            this.Owner = factionDto.Owner;
            this.officer1 = factionDto.officer1;
            this.officer2 = factionDto.officer2;
            this.officer3 = factionDto.officer3;
            this.officer4 = factionDto.officer4;
            this.officer5 = factionDto.officer5;
            this.officerChat = factionDto.officerChat;
            this.basicChat = factionDto.basicChat;
        }

        public FactionDto(int id, int houseId, string name, string owner, string officer1, string officer2, string officer3, string officer4, string officer5, string officerChat, string basicChat)
        {
            this.Id = id;
            this.HouseId = houseId;
            this.Name = name;
            this.Owner = owner;
            this.officer1 = officer1;
            this.officer2 = officer2;
            this.officer3 = officer3;
            this.officer4 = officer4;
            this.officer5 = officer5;
            this.officerChat = officerChat;
            this.basicChat = basicChat;
        }

    }
}