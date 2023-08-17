namespace JordyHandmade.Web.ViewModels.Category
{
	using System.ComponentModel.DataAnnotations;
	using static JordyHandmade.Common.EntityValidationConstants.Category;
	
	public class CategoryFormModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string CategoryName { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string Description { get; set; } = null!;		
	}
}
