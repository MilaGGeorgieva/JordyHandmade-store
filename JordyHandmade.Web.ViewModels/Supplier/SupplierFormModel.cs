namespace JordyHandmade.Web.ViewModels.Supplier
{
	using System;
	using System.ComponentModel.DataAnnotations;

	using static JordyHandmade.Common.EntityValidationConstants.Supplier;
	using static JordyHandmade.Common.EntityValidationConstants.Address;
	using static JordyHandmade.Common.EntityValidationConstants.Town;

	public class SupplierFormModel
	{		
        [Required]
		[StringLength(SupplierNameMaxLength, MinimumLength = SupplierNameMinLength)]
		public string SupplierName { get; set; } = null!;
				
		[StringLength(WebAddressMaxLength, MinimumLength = WebAddressMinLength)]
		[RegularExpression(WebAddressRegEx, ErrorMessage = "Web Address should be in the format http(s)://(www.)text.com(bg)(org)(us)(uk)")]
		public string? Website { get; set; }
				
		[EmailAddress]
		[StringLength(EmailAddressMaxLength, MinimumLength = EmailAddressMinLength)]
		public string? Email { get; set; }
				
		[Required]
		[StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		[StringLength(StreetAddressMaxLength, MinimumLength = StreetAddressMinLength)]
		public string StreetAddress { get; set; } = null!;

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string TownName { get; set; } = null!;

		[Required]
		[StringLength(ZipLength, MinimumLength = ZipLength)]
		[RegularExpression(ZipRegEx, ErrorMessage = "Zip code should contain only numbers!")]
		public string ZipCode { get; set; } = null!;

		[Required]
		public bool IsActive { get; set; }
	}
}
