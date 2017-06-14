using View.Base;

namespace Headquarters.VM
{
    public class MainViewModel
    {
        private IWindow _window;

        public PlayerViewModel PlayerViewModel { get; }

        public MainViewModel(PlayerViewModel playerViewModel)
        {
            PlayerViewModel = playerViewModel;
        }

        public MainViewModel(IWindow window, PlayerViewModel playerViewModel)
        {
            _window = window;
            PlayerViewModel = playerViewModel;
        }
    }
}