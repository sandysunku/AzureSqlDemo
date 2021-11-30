using System.ComponentModel;
using System.Windows.Input;

namespace AzureSqlXamarinDbDemo.Models
{
    public class PurchaseItem :  INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal MaxPrice { get; set; }
        private bool _isSelected;
        public ICommand DeleteItemCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; PropertyChanged(this, new PropertyChangedEventArgs("IsSelected")); }
        }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
