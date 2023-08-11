namespace JordyHandmade.Web.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public string Name { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string Email { get; set; } = null!;

        public string? TownName { get; set; }

        public string CustomerRating { get; set; } = null!;
    }
}
