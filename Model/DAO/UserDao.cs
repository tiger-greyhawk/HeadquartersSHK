using Model.Converter;
using Model.DTO;
using Model.Entity;
using Model.REST;

namespace Model.DAO
{
    public interface IUserDao
    {
        User GetMe();
        User CreateUser(User userToCreate);
    }

    public class UserDao : IUserDao
    {
        private readonly RestClient _restClient;
        private readonly ConverterJson _converterJson;

        public UserDao(RestClient restClient, ConverterJson converterJson)
        {
            _restClient = restClient;
            _converterJson = converterJson;
        }

        public User GetMe()
        {
            return _converterJson.ConvertJsonToUser(_restClient.DoGet("user/me"));
        }

        public User CreateUser(User userToCreate)
        {
            return _converterJson.ConvertJsonToUser(_restClient.DoPostAsync(_converterJson.ConvertUserToJson(userToCreate), "/user/register"));
        }
    }
}