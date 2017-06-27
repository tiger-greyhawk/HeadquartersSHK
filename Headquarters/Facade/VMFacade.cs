using Model.Converter;
using Model.DTO;
using Model.Entity;
using Model.Service;

namespace Headquarters.Facade
{
    public interface IVMFacade
    {
        UserDto Convert(User user);
        User Convert(UserDto userDto);
    }
    public class VMFacade : IVMFacade
    {
        private readonly IFactionPlayerService _factionPlayerService;
        private readonly IFactionService _factionService;
        private readonly IPlayerService _playerService;

        private readonly UserConverter _userConverter;

        public VMFacade(IFactionPlayerService factionPlayerService, IFactionService factionService, IPlayerService playerService)
        {
            _factionPlayerService = factionPlayerService;
            _factionService = factionService;
            _playerService = playerService;
            _userConverter = new UserConverter();
        }


        /***
         * Надо передавать сюда другие фасады и здесь собирать уже оттуда данные, а не из сервисов
         */
        public UserDto Convert(User user)
        {
            Player activePlayer = _playerService.FindById(user.ActivePlayerId);
            UserDto userDto = _userConverter.convert(user);
            
            return userDto;
        }

        public User Convert(UserDto userDto)
        {
            User user = _userConverter.convert(userDto);
            user.ActivePlayerId = userDto.ActivePlayer.Id;
            return user;
        }
    }
}