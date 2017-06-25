using System;
using System.Windows;
using System.Windows.Input;
using View.Base;

namespace Headquarters.Root
{
    public class WindowAdapter : Window, IWindow
    {
        private readonly Window _window;
        

        public WindowAdapter(Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }
            this._window = window;
        }

        #region IWindow Members
        public new virtual void Close()
        {
            base.Close();
            base.OnClosed(EventArgs.Empty);
        }

        public virtual IWindow CreateChildByViewModel(object viewModel, Window window)
        {
            window.Owner = this._window;
            window.DataContext = viewModel;
            WindowAdapter.ConfigureBehaviorByVM(window);
            return new WindowAdapter(window);
        }

        
        /*public virtual IWindow CreateChild(IWindow window, object viewModel)
        {
            Window cw = (Window)window;
            cw.Owner = this._window;
            cw.DataContext = viewModel;
            WindowAdapter.ConfigureBehavior(cw);
            return new WindowAdapter(cw);
        }*/
        

        public new virtual void Show()
        {
            this._window.Show();
        }

        public new virtual bool? ShowDialog()
        {
            return this._window.ShowDialog();
        }
        #endregion

        /*private static void ConfigureBehavior(RequestResourceEditorWindow cw)
        {
            cw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            cw.CommandBindings.Add(new CommandBinding(PresentationCommands.Accept, (sender, e) => cw.DialogResult = true));
            //cw.CommandBindings.Add(new CommandBinding(PresentationCommands.ShowGameFunctionalWindowCommand, (sender, e) => cw.DialogResult = false));
            //cw.CommandBindings.Add(new CommandBinding(new RoutedCommand("Accept", typeof(RoutedCommand)),
            //    (sender, e) => cw.DialogResult = true));
            // Закоментированная строка не сработает, ибо мы в xaml-коде обращаемся к статик. А Уровень ViewModel там недоступен ))
        }*/

        private static void ConfigureBehaviorByVM(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.CommandBindings.Add(new CommandBinding(ViewCommand.Accept, (sender, e) => window.DialogResult = true));
        }


    }
}