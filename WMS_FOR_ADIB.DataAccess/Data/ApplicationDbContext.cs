using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WMS_FOR_ADIB.Models;

namespace WMS_FOR_ADIB.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AssetDisposal> AssetDisposals { get; set; }
        public DbSet<AssetReturn> AssetReturns { get; set; }
        public DbSet<AssetRequistion> AssetRequistions { get; set; }
        public DbSet<AssetTransfer> AssetTransfers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring relationships
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.PurchaseOrders)
                .WithOne(po => po.Supplier)
                .HasForeignKey(po => po.SupplierID);

            modelBuilder.Entity<PurchaseRequisition>()
                .HasMany(pr => pr.PurchaseOrders)
                .WithOne(po => po.PurchaseRequisition)
                .HasForeignKey(po => po.PRNumber);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(po => po.Items)
                .WithOne(i => i.PurchaseOrder)
                .HasForeignKey(i => i.POId);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.AssetTransfers)
                .WithMany(at => at.Items);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.AssetReturns)
                .WithMany(ar => ar.Items);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.AssetDisposals)
                .WithMany(ad => ad.Items);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.AssetRequisitions)
                .WithMany(ar => ar.Items);

            modelBuilder.Entity<Item>()
                .Property(i => i.TotalPrice)
                .HasComputedColumnSql("[Quantity] * [UnitPrice]");
        }
    }
}
