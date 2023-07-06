using System.ComponentModel.DataAnnotations.Schema;

namespace JordyHandmade.Data.Models
{
    public class ProductPart
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        [ForeignKey(nameof(PartsInProduct))]
        public Guid PartId { get; set; }
        public virtual PartsInProduct PartsInProduct { get; set; } = null!;

        public double PartQuantity { get; set; }
    }
}
