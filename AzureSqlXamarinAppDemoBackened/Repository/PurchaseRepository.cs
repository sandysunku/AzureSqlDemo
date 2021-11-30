using AzureSqlXamarinAppDemoBackened.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using AzureSqlXamarinAppDemoBackened.DbContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AzureSqlXamarinAppDemoBackened.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly PurchaseContext _dbContext;

        public PurchaseRepository(PurchaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeletePurchaseItem(int id)
        {
            try
            {
                _dbContext.Remove(_dbContext.PurchaseItem.Single(a => a.Id == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public PurchaseItem GetPurchaseItemById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseItem> GetPurchaseItems()
        {
            return _dbContext.PurchaseItem.ToList();
        }

        public void InsertPurchaseItem(PurchaseItem purchaseItem)
        {
            try
            {
                _dbContext.Add(purchaseItem);
                Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public bool UpdatePurchaseItem(PurchaseItem purchaseItem)
        {
            try
            {
                _dbContext.Entry(purchaseItem).State = EntityState.Modified;
                Save();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
