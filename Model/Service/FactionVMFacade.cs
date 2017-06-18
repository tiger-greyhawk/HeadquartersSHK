using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Service
{
    public class FactionVmFacade
    {
        private readonly FactionPlayerService _factionPlayerService;
        private readonly FactionService _factionService;
        private readonly PlayerService _playerService;

        public FactionVmFacade(FactionPlayerService fps, FactionService fs, PlayerService ps)
        {
            _factionPlayerService = fps;
            _factionService = fs;
            _playerService = ps;
        }
    }
}
