namespace JordyHandmade.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static JordyHandmade.Common.EntityValidationConstants.Category;

    [Comment("Product categories table")]
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        
        [Key]
        public int Id { get; set; }

        [Comment("Category name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string CategoryName { get; set; } = null!;

        [Comment("Category description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public bool IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
