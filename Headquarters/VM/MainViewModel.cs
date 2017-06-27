using System;
using System.Windows;
using System.Windows.Input;
using Headquarters.Root;
using Model.DTO;
using Model.Entity;
using Model.Setting;
using View.Base;
using View.Window;

namespace Headquarters.VM
{
    public interface IMainViewModel
    {
        MainViewModel PrepareWindow(IWindow window);
    }

    public class MainViewModel : MainViewModelCommand, IMainViewModel
    {
        //private IWindow _window;


        //private ConnectionProperties _connectionProperties;



        //public IPlayerViewModel PlayerViewModel { get; }
        //public IFactionViewModel FactionViewModel { get; }

        public MainViewModel(ConnectionProperties connectionProperties, IPlayerViewModel playerViewModel, IFactionViewModel factionViewModel, IUserViewModel userViewModel) : 
            base(connectionProperties, playerViewModel, factionViewModel, userViewModel)
        {
            //_connectionProperties = connectionProperties;
            //PlayerViewModel = playerViewModel;
            //FactionViewModel = factionViewModel;
        }

        /*public MainViewModel(IWindow window, PlayerViewModel playerViewModel)
        {
            _window = window;
            PlayerViewModel = playerViewModel;
        }*/

        public MainViewModel PrepareWindow(IWindow window)
        {
            base._window = window;
            //_window = window;
            return this;
        }

        
    }
}