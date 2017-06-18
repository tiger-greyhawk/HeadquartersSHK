using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using Model.Entity;

namespace Model.Converter
{
    public class ConverterJson
    {
        public Player ConvertJsonToPlayer(string dataToSerialize)
        {
         
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Player));
            Player clear;
         
            try
            {
                clear = (Player)json.ReadObject(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(dataToSerialize)));
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //throw;
                clear = new Player();
            }
            //Player clear = (Player)json.ReadObject(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(dataToSerialize)));
            return clear;
        }

        public IEnumerable<Player> ConvertJsonToPlayers(string dataToSerialize)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Player));
            List<Player> clear;
            try
            {
                clear = (List<Player>)json.ReadObject(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(dataToSerialize)));
            }
            catch (Exception e)
            {
                clear = new List<Player>();
            }
            return clear;
        }

        public IEnumerable<FactionPlayer> ConvertJsonToFactionPlayers(string dataToSerialize)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(FactionPlayer));
            List<FactionPlayer> clear;
            try
            {
                clear = (List<FactionPlayer>)json.ReadObject(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(dataToSerialize)));
            }
            catch (Exception e)
            {
                clear = new List<FactionPlayer>();
            }
            return clear;
        }
        public IEnumerable<Faction> ConvertJsonToFactions(string dataToSerialize)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Faction));
            List<Faction> clear;
            try
            {
                clear = (List<Faction>)json.ReadObject(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(dataToSerialize)));
            }
            catch (Exception e)
            {
                clear = new List<Faction>();
            }
            return clear;
        }
    }
}