using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Converter;
using Model.REST;

namespace Model.DAO
{
    /**
     * Общее описание функционала любого ДАО
     */ 
    public interface IDao<T>
    {
        List<T> FindAll(string path, List<T> objects);
        T GetById(int id);
        bool Exists(int id);
        T Save(T value);
    }

    /**
     * Общая реализация любого ДАО
     */ 
    public class GenericDao<T> : IDao<T>
    {
        private readonly RestClient _restClient;
        private readonly ConverterJson _converterJson;
        public GenericDao(RestClient restClient, ConverterJson converterJson)
        {
            _restClient = restClient;
            _converterJson = converterJson;
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll(string path, List<T> objects)
        {
            _converterJson.Convert(path, objects);
            //return (List<T>)_converterJson.ConvertJsonToPlayers(_restClient.DoGet(path));
            return (List<T>)_converterJson.ConvertJsonToPlayers(_restClient.DoGet(path));
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Save(T value)
        {
            throw new NotImplementedException();
        }
    }

    /**
     * Общее описание ДАО игрока
     */
    public interface IExamplePlayerDao : IDao<Player>
    {
        Player FindByName(string name);
    }

    /**
     * Реализация ДАО игрока с переиспользованием общей реализации ДАО
     */
    public class ExamplePlayerDao : GenericDao<Player>, IExamplePlayerDao
    {
        //private readonly RestClient _restClient;
        //private readonly ConverterJson _converterJson;

        public ExamplePlayerDao(RestClient restClient, ConverterJson converterJson) : base(restClient, converterJson)
        {
            
        }

        public Player FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }

}
