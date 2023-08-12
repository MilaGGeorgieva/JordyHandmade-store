namespace JordyHandmade.Data
{
    using JordyHandmade.Data.Configurations;
    using JordyHandmade.Data.Models;
    using JordyHandmade.Data.Models.Enums;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class JordyHandmadeDbContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        public JordyHandmadeDbContext(DbContextOptions<JordyHandmadeDbContext> options)
            : base(options)
        {
            if (!this.Database.IsRelational())
            {
                this.Database.EnsureCreated();
            }
        }

        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ClientCard> ClientCards { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderProduct> OrdersProducts { get; set; } = null!;
        public DbSet<PartsInProduct> PartsInProducts { get; set; } = null!;
        public DbSet<ProductPart> ProductsParts { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPart>(e =>
            {
                e.HasKey(pp => new { pp.ProductId, pp.PartId });
            }); 

            modelBuilder.Entity<OrderProduct>(e =>
            {
                e.HasKey(op => new { op.OrderId, op.ProductId });
            });

            modelBuilder.Entity<PartsInProduct>()                
                .HasOne(pp => pp.Supplier)
                .WithMany(s => s.ProductParts)
                .HasForeignKey(pp => pp.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);            

            modelBuilder.Entity<ClientCard>()
                .HasOne(cc => cc.Customer)
                .WithOne(c => c.Card)
                .HasForeignKey<Customer>(c => c.CardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .Property(p => p.Rating)
                .HasDefaultValue(CustomerRating.New);

            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
            
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());

            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
                
            base.OnModelCreating(modelBuilder);
        }
    }
}