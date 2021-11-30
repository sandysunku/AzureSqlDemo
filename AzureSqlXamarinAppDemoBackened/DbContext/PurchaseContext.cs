using AzureSqlXamarinAppDemoBackened.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureSqlXamarinAppDemoBackened.DbContext
{
    public class PurchaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        {
        }

        public DbSet<PurchaseItem> PurchaseItem { get; set; }
    }
}
