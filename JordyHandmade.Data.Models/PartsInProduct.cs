namespace JordyHandmade.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static JordyHandmade.Common.EntityValidationConstants.PartsInProduct;

    [Comment("Parts in the product table")]
    public class PartsInProduct
    {
        public PartsInProduct()
        {
            this.Id = Guid.NewGuid();
            this.PartProducts = new HashSet<ProductPart>();
        }

        [Key]
        public Guid Id { get; set; }

        [Comment("Part name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string PartName { get; set; } = null!;

        [Comment("Part price")]
        public decimal PartPrice { get; set; }

        [Comment("Part quantity purchased")]
        public double QuantityPurchased  { get; set; }

        [Comment("Quantity measure unit")]
        [Required]
        [MaxLength(MeasureUnitMaxLength)]
        public string QuantityMeasureUnit { get; set; } = null!;

        [Comment("Part quantity left")]
        public double QuantityInStock { get; set; }

        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        public virtual ICollection<ProductPart> PartProducts { get; set; }
    }
}
