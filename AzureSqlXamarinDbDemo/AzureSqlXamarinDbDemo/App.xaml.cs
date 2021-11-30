using AzureSqlXamarinDbDemo.Dialogs;
using AzureSqlXamarinDbDemo.Services;
using AzureSqlXamarinDbDemo.ViewModels;
using AzureSqlXamarinDbDemo.Views;
using Prism.Ioc;
using Prism.Unity;

namespace AzureSqlXamarinDbDemo
{
    public partial class App : PrismApplication
    {
        public App()
        {
            InitializeComponent();

            MainPage = new OptionsPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DisplayPurchasePage, DisplayPurchasePageViewModel>();
            containerRegistry.RegisterForNavigation<OptionsPage, OptionsPageViewmodel>();
            containerRegistry.RegisterDialog<MessageDialog>();
            containerRegistry.RegisterDialog<AddModifyItemDialog>();
            containerRegistry.RegisterSingleton<IPurchaseOperationService, PurchaseOperationService>();
        }

        protected override void OnInitialized()
        {
        }
    }
}
