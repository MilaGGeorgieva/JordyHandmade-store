namespace JordyHandmade.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static JordyHandmade.Common.EntityValidationConstants.Town;

    [Comment("Table with towns")]
    public class Town
    {
        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        [Comment("Town Id")]
        [Key]
        public int Id { get; set; }

        [Comment("Town name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string TownName { get; set; } = null!;

        [Comment("Town 4-digit zip code")]
        [Required]
        [MaxLength(ZipLength)]
        public string ZipCode { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
