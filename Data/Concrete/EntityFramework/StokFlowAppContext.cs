using ModernWMC.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class StokFlowAppContext : IdentityDbContext<ApplicationUser>
    {

        public StokFlowAppContext(DbContextOptions<StokFlowAppContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<ContactMessage> ContactMessages { get; set; } = null!;
        public DbSet<About> Abouts { get; set; } = null!;
        public DbSet<Cta> Ctas { get; set; } = null!;
        public DbSet<Email> Emails { get; set; } = null!;
        public DbSet<Hero> Heroes { get; set; } = null!;
        public DbSet<Phone> Phones { get; set; } = null!;
        public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; } = null!;
        public DbSet<Statistics> Statistics { get; set; } = null!;
        public DbSet<SystemModulesDynamic> SystemModulesDynamics { get; set; } = null!;
        public DbSet<SystemModulesStatic> SystemModulesStatics { get; set; } = null!;
        public DbSet<TermsOfUse> TermsOfUses { get; set; } = null!;
        public DbSet<FAQ> FAQs { get; set; } = null!;
        public DbSet<Map> Maps { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Warehouse> Warehouses { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<MeasureUnit> MeasureUnits { get; set; } = null!;
        public DbSet<Inventory> Inventories { get; set; } = null!;
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; } = null!;
        public DbSet<Transfer> Transfers { get; set; } = null!;
        public DbSet<TransferItem> TransferItems { get; set; } = null!;





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StokFlowAppContext).Assembly);

            modelBuilder.Entity<PurchaseOrderItem>()
                .HasOne(poi => poi.PurchaseOrder)
                .WithMany(po => po.Items)
                .HasForeignKey(poi => poi.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchaseOrderItem>()
                .HasOne(poi => poi.Inventory)
                .WithMany()
                .HasForeignKey(poi => poi.InventoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.SourceWarehouse)
                .WithMany()
                .HasForeignKey(t => t.SourceWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.DestinationWarehouse)
                .WithMany()
                .HasForeignKey(t => t.DestinationWarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferItem>()
                .HasOne(ti => ti.Transfer)
                .WithMany(t => t.Items)
                .HasForeignKey(ti => ti.TransferId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransferItem>()
                .HasOne(ti => ti.Inventory)
                .WithMany()
                .HasForeignKey(ti => ti.InventoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}