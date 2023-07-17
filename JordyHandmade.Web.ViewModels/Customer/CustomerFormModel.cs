namespace JordyHandmade.Web.ViewModels.Customer
{
    using System.ComponentModel.DataAnnotations;
    using static JordyHandmade.Common.EntityValidationConstants.Address;
    using static JordyHandmade.Common.EntityValidationConstants.Town;

    public class CustomerFormModel
    {
        [Required]
        [StringLength(StreetAddressMaxLength, MinimumLength = StreetAddressMinLength)]
        public string StreetAddress { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string TownName { get; set; } = null!;

        [Required]
        [StringLength(ZipLength, MinimumLength = ZipLength)]
        public string ZipCode { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}
