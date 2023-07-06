namespace JordyHandmade.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    [Comment("Card for bonuses table")]
    public class ClientCard
    {
        public ClientCard()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Comment("Aggregated customer sales")]
        public decimal AggregatedSales { get; set; }

        [Comment("Earned bonus points")]
        public int? BonusPoints { get; set; }

        [Comment("Last updated on")]
        public DateTime ModifiedOn { get; set; }

        public Guid UserId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
    }
}
