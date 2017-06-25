using System;
using System.Windows;
using System.Windows.Input;
using Headquarters.Root;
using Model.DTO;
using Model.Entity;
using View.Base;
using View.Window;

namespace Headquarters.VM
{
    public interface IMainViewModel
    {
        MainViewModel PrepareWindow(IWindow window);
    }

    public class MainViewModel : IMainViewModel
    {
        private IWindow _window;
        private PlayersWindow _playersWindow;

        private readonly RelayCommand _showRegisterNewUserWindowCommand;
        private readonly RelayCommand _showPlayersWindowCommand;
        private readonly RelayCommand _exitCommand;

        public IPlayerViewModel PlayerViewModel { get; }

        public MainViewModel(IPlayerViewModel playerViewModel)
        {
            PlayerViewModel = playerViewModel;


            _showRegisterNewUserWindowCommand = new RelayCommand(ShowRegisterNewUserWindow);
            _showPlayersWindowCommand = new RelayCommand(ShowPlayersWindow);
            _exitCommand = new RelayCommand(Exit);
        }

        /*public MainViewModel(IWindow window, PlayerViewModel playerViewModel)
        {
            _window = window;
            PlayerViewModel = playerViewModel;
        }*/

        public MainViewModel PrepareWindow(IWindow window)
        {
            _window = window;
            return this;
        }

        public ICommand ShowRegisterNewUserWindowCommand => _showRegisterNewUserWindowCommand;
        public void ShowRegisterNewUserWindow(object parameter)
        {
            RegisterNewUserWindow window = new RegisterNewUserWindow();
            UserDto newUser = new UserDto(new User());

            if (_window.CreateChildByViewModel(newUser, window).ShowDialog() == true)
            {
                //if (_serviceCollection.UserService.SaveUser(newUser).Login == newUser.Login)
                    MessageBox.Show("", "");
                //newUser.Save(newUser);

            }

        }

        public ICommand ShowPlayersWindowCommand => _showPlayersWindowCommand;
        public void ShowPlayersWindow(object parameter)
        {
            try
            {
                _window.CreateChildByViewModel(PlayerViewModel, _playersWindow).Show();
            }
            catch (NullReferenceException e)
            {
                _playersWindow = new PlayersWindow();
                _window.CreateChildByViewModel(PlayerViewModel, _playersWindow).Show();
            }
            catch (InvalidOperationException e)
            {
                _playersWindow = new PlayersWindow();
                _window.CreateChildByViewModel(PlayerViewModel, _playersWindow).Show();
            }
        }

        public ICommand ExitCommand => _exitCommand; 
        public void Exit(object parameter)
        {
            _window.Close();
            Application.Current.Shutdown();
        }
    }
}