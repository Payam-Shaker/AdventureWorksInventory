using AdventureWorksInventory.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace AdventureWorksInventory
{
    public class InventoryDBcontext : DbContext
    {
        public InventoryDBcontext(DbContextOptions<InventoryDBcontext> options) : base(options)
        {
             
        }
        public virtual DbSet<SalesOrder> SalesOrderDetail { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.ToTable("SalesOrderDetail", "SalesLT");
            });
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "SalesLT");
            });
        }
    }
}
