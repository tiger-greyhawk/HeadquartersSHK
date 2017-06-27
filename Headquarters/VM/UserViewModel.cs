using System;
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
        void SaveUser();
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
            UserService = userService;
            _acceptCommand = new RelayCommand(Accept);
            MyUser = VMFacade.Convert(userService.GetMe());
        }

        public void SaveUser()
        {
            UserService.Save(VMFacade.Convert(MyUser));
            throw new NotImplementedException();
        }

        public ICommand AcceptCommand { get { return _acceptCommand; } }
        public void Accept(object parameter)
        {
            
        }
    }
}