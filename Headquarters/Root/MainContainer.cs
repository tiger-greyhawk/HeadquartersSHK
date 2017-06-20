using System.Windows;
using System.Windows.Interop;
using Headquarters.Facade;
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
            ConverterJson converterJson = new ConverterJson();
            IPlayerDao playerDao = new PlayerDao(restClient, converterJson);
            IFactionDao factionDao = new FactionDao(restClient, converterJson);
            IFactionPlayerDao factionPlayerDao = new FactionPlayerDao(restClient, converterJson);
            Mapper mapper = new Mapper();
            IPlayerService playerService = new PlayerService(playerDao);
            IFactionService factionService = new FactionService(factionDao);
            IFactionPlayerService factionPlayerService = new FactionPlayerService(factionPlayerDao);
            IPlayerVmFacade playerVmFacade = new PlayerVmFacade(factionPlayerService, factionService, playerService);
            PlayerViewModel playerViewModel = new PlayerViewModel(playerVmFacade);
            ViewModelFactory vmFactory = new ViewModelFactory(playerViewModel);

            Window main = new Main();
            _window = new MainWindowAdapter(main, vmFactory);
            return _window;
        }
    }
}