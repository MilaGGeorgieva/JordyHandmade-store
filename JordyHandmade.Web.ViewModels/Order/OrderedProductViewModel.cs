namespace JordyHandmade.Web.ViewModels.Order
{
    using System.ComponentModel.DataAnnotations;

    public class OrderedProductViewModel
    {
        public string ProductId { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int ProductQuantity { get; set; }

        //[DisplayFormat(DataFormatString = "{0:f2}")]
        public decimal ProductTotal { get; set; }        
    }
}
