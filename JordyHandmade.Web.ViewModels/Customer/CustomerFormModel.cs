namespace JordyHandmade.Web.ViewModels.Customer
{
    using System.ComponentModel.DataAnnotations;
    using static JordyHandmade.Common.EntityValidationConstants.Customer;
    using static JordyHandmade.Common.EntityValidationConstants.Address;
    using static JordyHandmade.Common.EntityValidationConstants.Town;

    public class CustomerFormModel
    {
        [Required]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(StreetAddressMaxLength, MinimumLength = StreetAddressMinLength)]
        public string StreetAddress { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string TownName { get; set; } = null!;

        [Required]
        [StringLength(ZipLength, MinimumLength = ZipLength)]
        public string ZipCode { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;

        [EmailAddress]
        [StringLength(EmailAddressMaxLength, MinimumLength = EmailAddressMinLength)]
        public string? Email { get; set; }
    }
}
