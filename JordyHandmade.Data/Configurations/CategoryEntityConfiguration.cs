namespace JordyHandmade.Data.Configurations
{    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using JordyHandmade.Data.Models;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
                
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;
            category = new Category()
            {
                Id = 1,
                CategoryName = "Home decoration",
                Description = "Home decoration for living room, kitchen, sleeping rooms. " +
                                "Pillows, placemats, Christmas, Easter and " +
                                "other occasions decorations. "
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                CategoryName = "Bags and totes",
                Description = "Crochet, denim or other fabrics women bags, totes, backpacks, beach bags."
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                CategoryName = "Embroidered items",
                Description = "Hand embroidered shirts, denim items, dresses, " +
                                "different style embroidery including Bulgarian traditional."
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
