using System;
using Headquarters.VM;
using View.Base;

namespace Headquarters.Root
{
    public class ViewModelFactory
    {
        private readonly PlayerViewModel _playerViewModel;

        public ViewModelFactory(PlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
        }




        public MainViewModel CreatePlayerVM(IWindow window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }
            return new MainViewModel(window, _playerViewModel);
        }
    }
}