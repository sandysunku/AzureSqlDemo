using AzureSqlXamarinDbDemo.Commands;
using AzureSqlXamarinDbDemo.Enums;
using AzureSqlXamarinDbDemo.Models;
using Newtonsoft.Json;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using AzureSqlXamarinDbDemo.Services;
using Xamarin.Forms;

namespace AzureSqlXamarinDbDemo.ViewModels
{
    public class DisplayPurchasePageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly IPurchaseOperationService _purchaseOperationService;
        private PurchaseItem _previousItem;
        private bool _refreshRequired = true;

        public DisplayPurchasePageViewModel(INavigationService navigationService, IDialogService dialogService, IPurchaseOperationService purchaseOperationService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _purchaseOperationService = purchaseOperationService;
            GetPurchasesCommand = new AsyncCommand(GetPurchases);
            AddItemCommand = new AsyncCommand(AddPurchaseItem);
        }

        private ObservableCollection<PurchaseItem> _purchaseItems;

        public ObservableCollection<PurchaseItem> PurchaseItems
        {
            get { return _purchaseItems; }
            set { SetProperty(ref _purchaseItems, value); }
        }

        private PurchaseItem _selectedPurchaseItem;

        public PurchaseItem SelectedPurchaseItem
        {
            get { return _selectedPurchaseItem; }
            set
            {
                if (value == null) return;
                if (_previousItem != null)
                    _previousItem.IsSelected = false;
                value.IsSelected = true;
                SetProperty(ref _selectedPurchaseItem, value);
                _previousItem = value;
            }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public ICommand GetPurchasesCommand { get; set; }
        public ICommand AddItemCommand { get; set; }


        public async void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (!_refreshRequired)
            {
                _refreshRequired = true;
                return;
            }

            IsBusy = true;
            await GetPurchases();
            IsBusy = false;
        }

        private async Task GetPurchases()
        {
            var items = await _purchaseOperationService.GetPurchaseItems();
            PurchaseItems = (ObservableCollection<PurchaseItem>)items;
            PurchaseItems.ToList().ForEach(x => x.DeleteItemCommand = new Command<int>(DeleteItem));
            PurchaseItems.ToList().ForEach(x => x.UpdateCommand = new Command<int>(UpdateItem));
        }

        private async Task AddPurchaseItem()
        {
            var dialogParameters = new DialogParameters()
            {
                {"operation", Operation.Add}
            };

            _dialogService.ShowDialog("AddModifyItemDialog", dialogParameters, HandleAddCallback);
            await GetPurchases();
        }

        private async void DeleteItem(int id)
        {
            var response = await _purchaseOperationService.DeletePurchaseItem(id);
            if (response)
            {
                var dialogParam = new DialogParameters()
                {
                    { "info", "Item deleted successfully." }
                };

                await _dialogService.ShowDialogAsync("MessageDialog", dialogParam);

                await GetPurchases();
            }
            else
            {
                var dialogParam = new DialogParameters()
                {
                    { "info", "Item failed to delete." }
                };

                await _dialogService.ShowDialogAsync("MessageDialog", dialogParam);
            }
        }

        private async void UpdateItem(int id)
        {
            var item = PurchaseItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return;

            var dialogParameters = new DialogParameters()
            {
                { "purchaseItem", item }, {"operation", Operation.Update}
            };

            _dialogService.ShowDialog("AddModifyItemDialog", dialogParameters, HandleModifyCallback);
        }

        private async void HandleModifyCallback(IDialogResult result)
        {
            _refreshRequired = result.Parameters.GetValue<bool>("refreshStatus");
            await _purchaseOperationService.UpdatePurchaseItem(result.Parameters.GetValue<PurchaseItem>("purchaseItem"));
            await GetPurchases();
        }

        private async void HandleAddCallback(IDialogResult result)
        {
            _refreshRequired = result.Parameters.GetValue<bool>("refreshStatus");
            await _purchaseOperationService.AddPurchaseItem(result.Parameters.GetValue<PurchaseItem>("purchaseItem"));
            await GetPurchases();
        }

    }
}
