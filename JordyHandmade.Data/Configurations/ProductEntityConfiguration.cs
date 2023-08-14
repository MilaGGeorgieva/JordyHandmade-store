namespace JordyHandmade.Data.Configurations
{    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using JordyHandmade.Data.Models;

    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            builder
                .Property(p => p.CreatedOn)
                .HasDefaultValue(DateTime.UtcNow);

            builder
                .Property(p => p.IsObsolete)
                .HasDefaultValue(false);            
        }        
    }
}
