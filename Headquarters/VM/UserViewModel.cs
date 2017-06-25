using System.Data;
using System.Windows.Input;
using Headquarters.Root;
using Model.DTO;

namespace Headquarters.VM
{
    public class UserViewModel
    {
        public UserDto UserDto { get; }
        private RelayCommand _acceptCommand;


        public UserViewModel(UserDto userDto)
        {
            UserDto = userDto;
            _acceptCommand = new RelayCommand(Accept);
        }

        public ICommand AcceptCommand { get { return _acceptCommand; } }
        public void Accept(object parameter)
        {
            
        }
    }
}