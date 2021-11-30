using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Windows.Input;

namespace AzureSqlXamarinDbDemo.Dialogs
{
    public class MessageDialogViewModel : BindableBase, IDialogAware
    {
        private string _information;

        public string Information
        {
            get { return _information; }
            set { SetProperty(ref _information, value); }
        }

        public ICommand OkCommand { get; set; }
        public event Action<IDialogParameters> RequestClose;

        public MessageDialogViewModel()
        {
            Information = "Terms and Conditions";
            OkCommand = new DelegateCommand(OnSubmitTapped);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        private void OnSubmitTapped()
        {
            RequestClose(new DialogParameters { { "action", true } });
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Information = parameters.GetValue<string>("info");
        }
    }
}
