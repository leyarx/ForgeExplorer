using ForgeExplorer.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ForgeExplorer.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private readonly ExplorerViewModel _explorerViewModel;

        private readonly Func<Task> ItemIsSelected;

        private readonly Item _item;

        public string Id => _item.Id;
        public string Name => _item.Name;
        public string Type => _item.Type;

        private bool _isExpanded;
        public bool IsExpanded {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;

                if(_isSelected)
                    ItemIsSelected?.Invoke();
            }
        }

        public ObservableCollection<ItemViewModel> Children { get; set; }
        public ObservableCollection<ItemViewModel> Content { get; set; }

        public ItemViewModel(ExplorerViewModel explorerViewModel, Item item)
        {
            _item = item;
            _explorerViewModel = explorerViewModel;

            Children = new ObservableCollection<ItemViewModel>();
            Content = new ObservableCollection<ItemViewModel>();

            ItemIsSelected = OnItemIsSelected;
        }

        protected async Task OnItemIsSelected()
        {
            _explorerViewModel.Content = Content;

            if (Children.Count == 0 && Content.Count == 0)
            {
                var items = await _explorerViewModel?.dataManagementController?.GetItemAsync(Id);

                foreach(var item in items)
                {
                    if(item.Type == "items")
                    {
                        Content.Add(new ItemViewModel(_explorerViewModel, item));
                    }
                    else
                    {
                        Children.Add(new ItemViewModel(_explorerViewModel, item));
                    }
                }

                IsExpanded = true;
            }
        }
    }
}
