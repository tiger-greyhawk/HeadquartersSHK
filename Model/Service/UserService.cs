using System.Collections.Generic;
using Model.DAO;
using Model.Entity;

namespace Model.Service
{
    public interface IUserService
    {
        User GetMe();
        void UpdateCache();
    }

    public class UserService : IUserService
    {
        private readonly IUserDao _userDao;
        private User _user;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
            _user = new User(0,"","",0);
        }

        /***
         * в данный момент запрашивает сервер и присваивает полученного пользователя приватному полю. Возвращает это значение.
         * В дальнейшем надо переделать на только возврат приватного поля. Апдейт делать через UpdateCache() в MainViewModel при коннекте и по таймеру.
         */
        public User GetMe()
        {
            _user = _userDao.GetMe();
            return _user;
        }

        /***
         * запрашивает с сервера значение текущего пользователя и присвает его приватному полю. 
         */
        public void UpdateCache()
        {
            _user = _userDao.GetMe();
        }
    }
}