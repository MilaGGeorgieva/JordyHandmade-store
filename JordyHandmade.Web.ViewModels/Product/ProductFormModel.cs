namespace JordyHandmade.Web.ViewModels.Product
{    
    using System.ComponentModel.DataAnnotations;

    using JordyHandmade.Web.ViewModels.Category;
    using static JordyHandmade.Common.EntityValidationConstants.Product;

    public class ProductFormModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
                
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;
                
        [Required]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string CreatedOn { get; set; } = null!;

        [Range(QuantityInStockMinValue, QuantityInStockMaxValue)]
        public int QuantityInStock { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategorySelectViewModel> Categories { get; set; } = null!;
    }
}
