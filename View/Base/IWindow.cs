using System.Windows;

namespace View.Base
{
    public interface IWindow
    {
        void Close();
        //IWindow CreateChild(object viewModel);
        IWindow CreateChildByViewModel(object viewModel, System.Windows.Window window);
        void Show();
        bool? ShowDialog();
    }
}