using System;
using System.Windows;

namespace Headquarters.Root
{
    public class MainWindowAdapter : WindowAdapter
    {
        private readonly ViewModelFactory _vmFactory;
        private readonly Window _window;

        public MainWindowAdapter(Window window, ViewModelFactory viewModelFactory)
            : base(window)
        {
            
            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }
            this._window = window;
            this._vmFactory = viewModelFactory;
        }
    }
}