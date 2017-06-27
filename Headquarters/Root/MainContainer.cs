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
using Model.Setting;
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

            IUserDao userDao = new UserDao(restClient, converterJson);
            IPlayerDao playerDao = new PlayerDao(restClient, converterJson);
            IFactionDao factionDao = new FactionDao(restClient, converterJson);
            IFactionPlayerDao factionPlayerDao = new FactionPlayerDao(restClient, converterJson);
            //Mapper mapper = new Mapper();
            Converter<Player, PlayerDto> playerConverter = new PlayerConverter();

            IUserService userService = new UserService(userDao);
            IPlayerService playerService = new PlayerService(playerDao);
            IFactionService factionService = new FactionService(factionDao);
            IFactionPlayerService factionPlayerService = new FactionPlayerService(factionPlayerDao);

            IVMFacade vmFacade = new VMFacade(factionPlayerService, factionService, playerService);
            IPlayerVmFacade playerVmFacade = new PlayerVmFacade(factionPlayerService, factionService, playerService);
            IFactionVmFacade factionVmFacade = new FactionVmFacade(factionPlayerService, factionService, playerService);

            IUserViewModel userViewModel = new UserViewModel(vmFacade, userService);
            IPlayerViewModel playerViewModel = new PlayerViewModel(playerVmFacade);
            IFactionViewModel factionViewModel = new FactionViewModel(factionVmFacade);
            IMainViewModel mainViewModel = new MainViewModel(connectionProperties, playerViewModel, factionViewModel, userViewModel);
            ViewModelFactory vmFactory = new ViewModelFactory(mainViewModel);

            Window main = new Main();
            
            _window = new MainWindowAdapter(main, vmFactory);
            //vmFactory.CreatePlayerVM(_window);
            return _window;
        }
    }
}