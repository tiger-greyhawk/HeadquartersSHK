using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Headquarters.Root;

namespace Headquarters

{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static MainContainer _mainContainer;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _mainContainer = new MainContainer();
            _mainContainer.ResolveWindow().Show();
        }
    }
}
