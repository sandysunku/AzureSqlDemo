using AzureSqlXamarinDbDemo.Enums;
using AzureSqlXamarinDbDemo.Models;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Windows.Input;
using AzureSqlXamarinDbDemo.Services;
using Prism.Commands;

namespace AzureSqlXamarinDbDemo.Dialogs
{
    public class AddModifyItemDialogViewModel : BindableBase, IDialogAware
    {
        public event Action<IDialogParameters> RequestClose;
        private Operation _operation;
        private int _id;
        private readonly IPurchaseOperationService _purchaseOperationService;


        public AddModifyItemDialogViewModel(IPurchaseOperationService purchaseOperationService)
        {
            CloseCommand = new DelegateCommand(() => { RequestClose(new DialogParameters() { { "refreshStatus", false } }); });
            AddModifyItemCommand = new DelegateCommand(OnSubmitTapped);
            _purchaseOperationService = purchaseOperationService;
        }

        public ICommand CloseCommand { get; set; }

        public ICommand AddModifyItemCommand { get; set; }

        private string _contextText;

        public string ContextText
        {
            get { return _contextText; }
            set { SetProperty(ref _contextText, value); }
        }

        private string _itemName;

        public string ItemName
        {
            get { return _itemName; }
            set { SetProperty(ref _itemName, value); }
        }

        private string _itemDescription;

        public string ItemDescription
        {
            get { return _itemDescription; }
            set { SetProperty(ref _itemDescription, value); }
        }

        private string _itemAmount;

        public string ItemAmount
        {
            get { return _itemAmount; }
            set { SetProperty(ref _itemAmount, value); }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            _operation = parameters.GetValue<Operation>("operation");
            if (_operation == Operation.Update)
            {
                HandleUpdateData(parameters.GetValue<PurchaseItem>("purchaseItem"));
                ContextText = "Update";
            }
            else
            {
                ContextText = "Add";
            }
        }

        private void OnSubmitTapped()
        {
            var purchaseItem = new PurchaseItem() { Id = _id, ItemName = ItemName, Description = ItemDescription, MaxPrice = int.Parse(ItemAmount) };
            RequestClose(new DialogParameters { { "purchaseItem", purchaseItem }, { "operation", _operation }, { "refreshStatus", true } });
        }

        private void HandleUpdateData(PurchaseItem purchaseItem)
        {
            _id = purchaseItem.Id;
            ItemName = purchaseItem.ItemName;
            ItemDescription = purchaseItem.Description;
            ItemAmount = purchaseItem.MaxPrice.ToString();
        }
    }
}
