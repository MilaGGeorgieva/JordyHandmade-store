namespace JordyHandmade.Data.Configurations
{    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using JordyHandmade.Data.Models;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(c => c.IsActive)
                .HasDefaultValue(true);                            
        }        
    }
}
