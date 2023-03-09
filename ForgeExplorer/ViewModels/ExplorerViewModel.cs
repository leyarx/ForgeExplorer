using ForgeExplorer.Core;
using System.Windows;
using System.Windows.Input;

namespace ForgeExplorer.ViewModels
{
    public class ExplorerViewModel
    {
        public ICommand CloseCommand { get; }

        public ExplorerViewModel()
        {
            CloseCommand = new RelayCommand<object>(CloseApp);
        }
        private void CloseApp(object obj)
        {
            Window win = obj as Window;
            win?.Close();
        }
    }
}
