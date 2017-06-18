using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DAO
{
    /**
     * Общее описание функционала любого ДАО
     */ 
    public interface IDao<T>
    {
        List<T> FindAll();
        T GetById(int id);
        bool Exists(int id);
        T Save(T value);
    }

    /**
     * Общая реализация любого ДАО
     */ 
    public class GenericDao<T> : IDao<T>
    {
        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll()
        {
            throw new NotImplementedException();
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
        public Player FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }

}
