namespace JordyHandmade.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static JordyHandmade.Common.EntityValidationConstants.Address;

    [Comment("Adresses table")]
    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid();
            this.Customers = new HashSet<Customer>();
        }
        
        [Key]
        public Guid Id { get; set; }

        [Comment("Street with number")]
        [Required]
        [MaxLength(StreetAddressMaxLength)]
        public string StreetAddress { get; set; } = null!;

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public virtual Town Town { get; set; } = null!;

        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
