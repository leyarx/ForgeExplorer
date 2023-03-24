using ForgeExplorer.Core;
using ForgeExplorer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ForgeExplorer.ViewModels
{
    public class ExplorerViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public ICommand ReloadCommand { get; }

        private readonly ObservableCollection<ItemViewModel> _items;
        public IEnumerable<ItemViewModel> Items => _items;

        private IList<ItemViewModel> _content;
        public IList<ItemViewModel> Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        private string _logLabel;
        public string LogLabel
        {
            get { return _logLabel; }
            set { SetProperty(ref _logLabel, value); }
        }

        public DataManagementController dataManagementController;

        public ExplorerViewModel()
        {
            dataManagementController = new DataManagementController();

            CloseCommand = new RelayCommand<object>(CloseApp);
            ReloadCommand = new AsyncRelayCommand(Reload, (ex) => LogLabel = ex.Message);

            _items = new ObservableCollection<ItemViewModel>();
            _content = new ObservableCollection<ItemViewModel>();
        }

        private void CloseApp(object obj)
        {
            Window win = obj as Window;
            win?.Close();
        }

        private async Task Reload()
        {
            LogLabel = "Start loading...";
            _items.Clear();
            _content.Clear();

            var hubs = await dataManagementController?.GetItemAsync("#");

            foreach(var hub in hubs)
            {
                _items.Add(new ItemViewModel(this, hub));
            }

            LogLabel = "Loaded";
        }
    }
}
