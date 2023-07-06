namespace JordyHandmade.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static JordyHandmade.Common.EntityValidationConstants.Supplier;

    [Comment("Supplier of parts table")]
    public class Supplier
    {
        public Supplier()
        {
            this.Id = Guid.NewGuid();
            this.ProductParts = new HashSet<PartsInProduct>();
        }
        
        [Key]
        public Guid Id { get; set; }

        [Comment("Supplier name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string SupplierName { get; set; } = null!;

        [Comment("Supplier web site")]
        [MaxLength(WebAddressMaxLength)]
        public string? Website { get; set; }

        [Comment("Supplier email")]
        [EmailAddress]
        [MaxLength(EmailAddressMaxLength)]
        public string? Email { get; set; }

        [Comment("Supplier phone number")]
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;

        public virtual ICollection<PartsInProduct> ProductParts { get; set; }
    }
}
