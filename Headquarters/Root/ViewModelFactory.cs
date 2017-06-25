using System;
using Headquarters.VM;
using View.Base;

namespace Headquarters.Root
{
    public class ViewModelFactory
    {
        private readonly IMainViewModel _mainViewModel;
        //private readonly PlayerViewModel _playerViewModel;

        public ViewModelFactory(IMainViewModel mainViewModel)//, PlayerViewModel playerViewModel)
        {
            _mainViewModel = mainViewModel;
            //_playerViewModel = playerViewModel;
        }

        public IMainViewModel Prepare(IWindow window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }
            _mainViewModel.PrepareWindow(window);
            return _mainViewModel;
        }

        /*public MainViewModel Create(IWindow window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }
            return new MainViewModel(window, _playerViewModel);
        }*/


        /*public MainViewModel CreatePlayerVM(IWindow window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }
            return new MainViewModel(window, _playerViewModel);
        }*/
    }
}