using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using Model.Entity;

namespace Model.Converter
{
    public interface IConverterJson<A, B>
    {
        B Convert(string dataToSerialize, A o);
    }

    public class ConverterJson: IConverterJson<IEnumerable<Player>, IEnumerable<Player>>, IConverterJson<IEnumerable<Faction>,IEnumerable<Faction>>
    {
        public IEnumerable<Player> Convert(string dataToSerialize, IEnumerable<Player> players)
        {
            players = ConvertJsonToPlayers(dataToSerialize);
            return players;
        }

        public IEnumerable<Faction> Convert(string dataToSerialize, IEnumerable<Faction> result)
        {
            result = ConvertJsonToFactions(dataToSerialize);
            return result;
        }

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
                clear = new Player(0,0,"");
            }
            //Player clear = (Player)json.ReadObject(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(dataToSerialize)));
            return clear;
        }

        public IEnumerable<Player> ConvertJsonToPlayers(string dataToSerialize)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Player>));
            List<Player> clear = new List<Player>();
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
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<FactionPlayer>));
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
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(List<Faction>));
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