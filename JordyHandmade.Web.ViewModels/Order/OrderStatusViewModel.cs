namespace JordyHandmade.Web.ViewModels.Order
{
    public class OrderStatusViewModel
    {
        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int ProductQuantity { get; set; }

        public decimal ProductTotal { get; set; }

        public decimal OrderTotal { get; set; }
    }
}
