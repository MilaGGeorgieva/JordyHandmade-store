namespace JordyHandmade.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderProduct
    {
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductQuantity { get; set; }
    }
}
