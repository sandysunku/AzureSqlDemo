using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace AzureSqlXamarinDbDemo.ViewModels
{
    public class OptionsPageViewmodel
    {
        private readonly INavigationService _navigationService;

        public OptionsPageViewmodel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            DisplayCommand = new Command(Display);
        }

        public ICommand DisplayCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private void Display()
        {
            _navigationService.NavigateAsync("DisplayPurchasePage");
        }
    }
}
