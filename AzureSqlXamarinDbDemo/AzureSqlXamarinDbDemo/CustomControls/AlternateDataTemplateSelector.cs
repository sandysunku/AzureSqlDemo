using AzureSqlXamarinDbDemo.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AzureSqlXamarinDbDemo.CustomControls
{
    public class AlternateColorDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenTemplate { get; set; }
        public DataTemplate UnevenTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // TODO: Maybe some more error handling here
            return ((ObservableCollection<PurchaseItem>)((ListView)container).ItemsSource).IndexOf(item as PurchaseItem) % 2 == 0 ? EvenTemplate : UnevenTemplate;
        }
    }
}
