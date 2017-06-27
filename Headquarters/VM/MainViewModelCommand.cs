using System;
using System.Windows;
using System.Windows.Input;
using Headquarters.Root;
using Model.DTO;
using Model.Entity;
using Model.Service;
using Model.Setting;
using View.Base;
using View.Window;

namespace Headquarters.VM
{
    public class MainViewModelCommand
    {
        public IWindow _window;

        private PlayersWindow _playersWindow;
        private FactionsWindow _factionsWindow;
        private AuthOptionsWindow _authOptionsWindow;

        private ConnectionProperties _connectionProperties;

        public IPlayerViewModel PlayerViewModel { get; }
        public IFactionViewModel FactionViewModel { get; }
        public IUserViewModel UserViewModel { get; }

        private readonly RelayCommand _showRegisterNewUserWindowCommand;
        private readonly RelayCommand _showPlayersWindowCommand;
        private readonly RelayCommand _showFactionsWindowCommand;
        private readonly RelayCommand _showAuthOptionsWindowCommand;
        private readonly RelayCommand _connectCommand;
        private readonly RelayCommand _exitCommand;

        public MainViewModelCommand(ConnectionProperties connectionProperties,
            IPlayerViewModel playerViewModel,
            IFactionViewModel factionViewModel,
            IUserViewModel userViewModel)
        {
            _connectionProperties = connectionProperties;
            PlayerViewModel = playerViewModel;
            FactionViewModel = factionViewModel;
            UserViewModel = userViewModel;

            _showRegisterNewUserWindowCommand = new RelayCommand(ShowRegisterNewUserWindow);
            _showPlayersWindowCommand = new RelayCommand(ShowPlayersWindow);
            _showFactionsWindowCommand = new RelayCommand(ShowFactionsWindow);
            _showAuthOptionsWindowCommand = new RelayCommand(ShowAuthOptionsWindow);

            _exitCommand = new RelayCommand(Exit);
        }

        public ICommand ShowRegisterNewUserWindowCommand => _showRegisterNewUserWindowCommand;
        public void ShowRegisterNewUserWindow(object parameter)
        {
            RegisterNewUserWindow window = new RegisterNewUserWindow();
            //UserDto newUser = new UserDto(new User(0,"","",0));
            


            if (_window.CreateChildByViewModel(UserViewModel, window).ShowDialog() == true)
            {
                //if (_serviceCollection.UserService.SaveUser(newUser).Login == newUser.Login)
                this.UserViewModel.SaveUser();
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

        public ICommand ShowFactionsWindowCommand => _showFactionsWindowCommand;
        public void ShowFactionsWindow(object parameter)
        {
            try
            {
                _window.CreateChildByViewModel(FactionViewModel, _factionsWindow).Show();
            }
            catch (NullReferenceException e)
            {
                _factionsWindow = new FactionsWindow();
                _window.CreateChildByViewModel(FactionViewModel, _factionsWindow).Show();
            }
            catch (InvalidOperationException e)
            {
                _factionsWindow = new FactionsWindow();
                _window.CreateChildByViewModel(FactionViewModel, _factionsWindow).Show();
            }
        }

        public ICommand ShowAuthOptionsWindowCommand => _showAuthOptionsWindowCommand;
        public void ShowAuthOptionsWindow(object parameter)
        {
            _authOptionsWindow = new AuthOptionsWindow();
            if (_window.CreateChildByViewModel(_connectionProperties, _authOptionsWindow).ShowDialog() == true)
            {
                //if (_serviceCollection.UserService.SaveUser(newUser).Login == newUser.Login)
                _connectionProperties.Save(_connectionProperties);

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