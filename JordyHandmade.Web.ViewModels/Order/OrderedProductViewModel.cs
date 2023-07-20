namespace JordyHandmade.Web.ViewModels.Order
{
    public class OrderedProductViewModel
    {
        public string ProductId { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int ProductQuantity { get; set; }

        public decimal ProductTotal { get; set; }        
    }
}
