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

            builder.HasData(this.GenerateProducts());
        }

        private Product[] GenerateProducts() 
        {
            ICollection<Product> products = new HashSet<Product>();

            Product product;

            product = new Product()
            {
                Name = "Heart pillow",
                Description = "Sweet heart-like pillow for decoration. " +
                                "Made with pure cotton cover and decorated with beads. " +
                                "Ideal for Valentine's gifts!",
                ImageUrl = "/Images/ProductImages/HeartPillows.jpg",
                Price = 20.00M,
                QuantityInStock = 6,
                CategoryId = 1
            };
            products.Add(product);

            product = new Product()
            {
                Name = "Bright sunny backpack",
                Description = "Crochet backpack/sack in sunny/summer pattern. " +
                                "Lined with 100% cotton inside in yellow color with polka dots, " +
                                "has 2 pockets - suitable for mobilephones. " +
                                "Ideal for sea beach or city life!",
                ImageUrl = "/Images/ProductImages/SunnyBackpack.jpg",
                Price = 25.00M,
                QuantityInStock = 1,
                CategoryId = 2
            };
            products.Add(product);

            product = new Product()
            {
                Name = "Girlish style denim bag set",
                Description = "A small jeans bag with hand embroidered kittens. " +
                                "Lined with bright green linen, 5 pockets, snap buttons, " +
                                "has a matching mobile phone case with velcro bands and " +
                                "a small coin purse with zipper. ",
                ImageUrl = "/Images/ProductImages/DenimBagSet.jpg",
                Price = 29.00M,
                QuantityInStock = 1,
                CategoryId = 2
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}
