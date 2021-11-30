using AzureSqlXamarinAppDemoBackened.Models;
using AzureSqlXamarinAppDemoBackened.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AzureSqlXamarinAppDemoBackened.Controllers
{
    [ApiController()]
    [Route("api/purchaseitems")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_purchaseRepository.GetPurchaseItems());
        }

        [HttpPost]
        public IActionResult Post([FromBody] PurchaseItem purchaseItem)
        {
            _purchaseRepository.InsertPurchaseItem(purchaseItem);
            return CreatedAtAction(nameof(Get), new { id = purchaseItem.Id }, purchaseItem);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_purchaseRepository.DeletePurchaseItem(id))
            {
                return new OkResult();
            }

            return new NotFoundResult();
        }

        [HttpPut]
        public IActionResult Update([FromBody] PurchaseItem purchaseItem)
        {
            if (_purchaseRepository.UpdatePurchaseItem(purchaseItem))
            {
                return new OkResult();
            }

            return new NotFoundResult();
        }
    }
}
