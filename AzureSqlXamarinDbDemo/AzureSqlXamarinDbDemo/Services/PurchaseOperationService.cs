using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AzureSqlXamarinDbDemo.Models;
using Newtonsoft.Json;

namespace AzureSqlXamarinDbDemo.Services
{
    public class PurchaseOperationService : IPurchaseOperationService
    {
        public async Task<bool> AddPurchaseItem(PurchaseItem purchaseItem)
        {
            var response = await new HttpClient().PostAsync(Constants.ApiUri, new StringContent(JsonConvert.SerializeObject(purchaseItem), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeletePurchaseItem(int id)
        {
            var response = await new HttpClient().DeleteAsync(Constants.ApiUri + id);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<Collection<PurchaseItem>> GetPurchaseItems()
        {
            var response = await new HttpClient().GetAsync(Constants.ApiUri);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ObservableCollection<PurchaseItem>>(responseContent);
        }

        public async Task<bool> UpdatePurchaseItem(PurchaseItem purchaseItem)
        {
            var response = await new HttpClient().PutAsync(Constants.ApiUri, new StringContent(JsonConvert.SerializeObject(purchaseItem), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
