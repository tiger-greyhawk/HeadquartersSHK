using System.Windows;
using System.Windows.Interop;
using Headquarters.Facade;
using Headquarters.VM;
using Model.Converter;
using Model.DAO;
using Model.DTO;
using Model.Entity;
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
            ConnectionProperties connectionProperties = new ConnectionProperties();
            RestClient restClient = new RestClient(connectionProperties);
            ConverterJson converterJson = new ConverterJson();
            IPlayerDao playerDao = new PlayerDao(restClient, converterJson);
            IFactionDao factionDao = new FactionDao(restClient, converterJson);
            IFactionPlayerDao factionPlayerDao = new FactionPlayerDao(restClient, converterJson);
            //Mapper mapper = new Mapper();
            Converter<Player, PlayerDto> playerConverter = new PlayerConverter();
            IPlayerService playerService = new PlayerService(playerDao);
            IFactionService factionService = new FactionService(factionDao);
            IFactionPlayerService factionPlayerService = new FactionPlayerService(factionPlayerDao);
            IPlayerVmFacade playerVmFacade = new PlayerVmFacade(factionPlayerService, factionService, playerService, playerConverter);
            IPlayerViewModel playerViewModel = new PlayerViewModel(playerVmFacade);
            IMainViewModel mainViewModel = new MainViewModel(playerViewModel);
            ViewModelFactory vmFactory = new ViewModelFactory(mainViewModel);

            Window main = new Main();
            
            _window = new MainWindowAdapter(main, vmFactory);
            //vmFactory.CreatePlayerVM(_window);
            return _window;
        }
    }
}