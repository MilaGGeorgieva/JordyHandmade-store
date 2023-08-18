namespace JordyHandmade.Web.ViewModels.Order
{
    public class OrderStatusViewModel
    {
        public string OrderId { get; set; } = null!;

        public string? Status { get; set; }

        public IEnumerable<OrderedProductViewModel> OrderedProducts { get; set; } = null!;

        public decimal OrderTotal { get; set; }

        public string StartDate { get; set; } = null!;
    }
}
