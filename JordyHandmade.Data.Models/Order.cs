namespace JordyHandmade.Data.Models
{    
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using JordyHandmade.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    [Comment("Customer orders table")]
    public class Order
    {
        public Order()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }
        
        [Key]
        public Guid Id { get; set; }

        [Comment("Date order made")]
        public DateTime StartDate { get; set; }

        [Comment("Date order completed")]
        public DateTime? EndDate { get; set; }

        [Comment("Order progress")]
        public OrderStatus Status { get; set; }

        [Comment("Given customer discount")]
        public int Discount { get; set; }

        [Comment("Total amount of purchase")]
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
 