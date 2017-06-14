using System.Windows;
using System.Windows.Interop;
using Headquarters.VM;
using Model.Converter;
using Model.DAO;
using Model.REST;
using Model.Service;
using View.Base;
using View.Window;

namespace Headquarters.Root
{
    public class MainContainer
    {
        private IWindow _window;

        public IWindow ResolveWindow()
        {
            RestClient restClient = new RestClient();
            PlayerDao playerDao = new PlayerDao(restClient);
            Mapper mapper = new Mapper();
            PlayerService playerService = new PlayerService(playerDao, mapper);
            PlayerViewModel playerViewModel = new PlayerViewModel(playerService);
            ViewModelFactory vmFactory = new ViewModelFactory(playerViewModel);

            Window main = new Main();
            _window = new MainWindowAdapter(main, vmFactory);
            return _window;
        }
    }
}