using AzureSqlXamarinAppDemoBackened.Models;
using System.Collections.Generic;

namespace AzureSqlXamarinAppDemoBackened.Repository
{
    public interface IPurchaseRepository
    {
        IEnumerable<PurchaseItem> GetPurchaseItems();
        PurchaseItem GetPurchaseItemById(int id);
        void InsertPurchaseItem(PurchaseItem purchaseItem);
        bool UpdatePurchaseItem(PurchaseItem purchaseItem);
        bool DeletePurchaseItem(int id);
        void Save();
    }
}
