namespace JordyHandmade.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static JordyHandmade.Common.EntityValidationConstants.Product;

    [Comment("Product table")]
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
            this.ProductParts = new HashSet<ProductPart>();
            this.ProductOrders = new HashSet<OrderProduct>();
        }
        
        [Key]
        public Guid Id { get; set; }

        [Comment("Product name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Product description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Product photo")]
        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Comment("Product price")]
        public decimal Price { get; set; }

        [Comment("Date product was created")]
        public DateTime CreatedOn { get; set; }

        [Comment("Product quantity available")]
        public int QuantityInStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public bool IsObsolete { get; set; }

        public virtual ICollection<ProductPart> ProductParts { get; set; }

        public virtual ICollection<OrderProduct> ProductOrders { get; set; }
    }
}