using System;
using System.Windows;
using System.Windows.Input;
using View.Base;

namespace Headquarters.Root
{
    public class MainWindowAdapter : WindowAdapter
    {
        private readonly ViewModelFactory _vmFactory;
        private readonly Window _window;
        private bool _initialized;


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

        #region IWindow Members

        public override void Close()
        {
            //this.EnsureInitialized();
            base.Close();
            _initialized = false;
        }

        /*public override IWindow CreateChild(object viewModel)
        {
            this.EnsureInitialized();
            return base.CreateChild(viewModel);
        }*/

        public override void Show()
        {
            this.EnsureInitialized();
            //this.ShowActivated = false;
            base.Show();
            //WpfWindow.Activate();

        }

        public override bool? ShowDialog()
        {
            this.EnsureInitialized();
            return base.ShowDialog();
        }

        #endregion

        private void EnsureInitialized()
        {
            if (this._initialized)
            {
                return;
            }

            var vm = this._vmFactory.Prepare(this);
            this._window.DataContext = vm;
            //this.DeclareKeyBindings(vm);

            /*var myCommandBinding = new CommandBinding(
                    PresentationCommands.ShowGameFunctionalWindow,
                    vm.AddRR_Executed,
                    vm.AddRR_CanExecute);*/
            //CommandBinding bind = new CommandBinding(PresentationCommands.ShowGameFunctionalWindow);

            // Присоединение обработчика событий

            // Регистрация привязки
            //CommandBindings.Add(bind);
            _window.CommandBindings.Add(new CommandBinding(ViewCommand.Accept, (sender, e) => _window.DialogResult = true));
            //_window.CommandBindings.Add(new CommandBinding(ViewCommand.ShowGameFunctionalWindowCommand, vm.ShowGameFunctionalWindow));
            //_window.CommandBindings.Add(new CommandBinding(PresentationCommands.ShowFactionsWindowCommand, vm.ShowFactionsWindow));
            //_window.CommandBindings.Add(new CommandBinding(PresentationCommands.Exit, vm.Exit));
            //WpfWindow.CommandBindings.Add(new CommandBinding(PresentationCommands.Connect, vm.Connect));
            //CommandBindings.Add(bind);
            //CommandManager.RegisterClassCommandBinding(typeof(PresentationCommands), bind);
            this._initialized = true;
        }
    }
}