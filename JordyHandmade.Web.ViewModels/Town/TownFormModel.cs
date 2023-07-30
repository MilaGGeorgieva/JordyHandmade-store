namespace JordyHandmade.Web.ViewModels.Town
{
    using System.ComponentModel.DataAnnotations;
    using static JordyHandmade.Common.EntityValidationConstants.Town;

    public class TownFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string TownName { get; set; } = null!;

        [Required]
        [StringLength(ZipLength, MinimumLength = ZipLength)]
        [RegularExpression(ZipRegEx)]
        public string ZipCode { get; set; } = null!;
    }
}
