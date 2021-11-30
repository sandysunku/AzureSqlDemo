using AzureSqlXamarinDbDemo.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AzureSqlXamarinDbDemo.Services
{
    public interface IPurchaseOperationService
    {
        Task<bool> AddPurchaseItem(PurchaseItem purchaseItem);
        Task<bool> UpdatePurchaseItem(PurchaseItem purchaseItem);
        Task<bool> DeletePurchaseItem(int id);
        Task<Collection<PurchaseItem>> GetPurchaseItems();
    }
}
