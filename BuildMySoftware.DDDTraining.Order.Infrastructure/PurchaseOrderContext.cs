using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BuildMySoftware.DDDTraining.Order
{
    public class PurchaseOrderContext : DbContext
    {
        public DbSet<PurchaseOrderDb> PurchaseOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }
    }

    public class PurchaseOrderDb
    {
        public decimal MaxTotalCostAmount { get; set; }
        public bool MaxTotalCostLimited { get; set; }
        public string MaxTotalCostCurrency { get; set; }
        public Guid Id { get; set; }
        public int MaxQuantityPerProduct { get; set; }
        public List<OrderItemDb> Items { get; set; }
    }

    public class OrderItemDb
    {
        public Guid Id { get; set; } 
        public int Quantity { get; set; }
        public string Product { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPriceCurrency { get; set; }
    }
}