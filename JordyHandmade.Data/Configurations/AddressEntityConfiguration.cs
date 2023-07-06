namespace JordyHandmade.Data.Configurations
{    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using JordyHandmade.Data.Models;

    public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasOne(a => a.Supplier)
                .WithOne(s => s.Address)
                .HasForeignKey<Supplier>(s => s.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(a => a.Customers)
                .WithOne(c => c.Address)
                .HasForeignKey(c => c.AddressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
