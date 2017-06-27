using System.Data;
using System.Windows.Input;
using Headquarters.Facade;
using Headquarters.Root;
using Model.DTO;
using Model.Service;

namespace Headquarters.VM
{
    public interface IUserViewModel
    {
        
    }

    public class UserViewModel: IUserViewModel
    {
        public IVMFacade VMFacade { get; }
        public IUserService UserService { get; }

        public UserDto MyUser { get; set; }

        private RelayCommand _acceptCommand;


        public UserViewModel(IVMFacade vmFacade, IUserService userService)
        {
            VMFacade = vmFacade;
            _acceptCommand = new RelayCommand(Accept);
            MyUser = VMFacade.Convert(userService.GetMe());
        }



        public ICommand AcceptCommand { get { return _acceptCommand; } }
        public void Accept(object parameter)
        {
            
        }
    }
}