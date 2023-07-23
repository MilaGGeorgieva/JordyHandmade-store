namespace JordyHandmade.Data.Models
{    
    using Microsoft.AspNetCore.Identity;

    using JordyHandmade.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static JordyHandmade.Common.EntityValidationConstants.Customer;

    [Comment("Customers table")]
    public class Customer : IdentityUser<Guid>
    {
        public Customer()
        {
            this.Id = Guid.NewGuid();
            this.Orders = new HashSet<Order>();
        }

        [Comment("Customer First and Last name")]
        [MaxLength(CustomerNameMaxLength)]
        public string? CustomerName { get; set; }

        [Comment("Rating of the customer")]
        public CustomerRating Rating { get; set; }

        public Guid? AddressId { get; set; }
        public Address? Address { get; set; }

        public Guid? CardId { get; set; }
        public virtual ClientCard? Card { get; set; } = null!;

        public ICollection<Order> Orders { get; set; }
    }
}
