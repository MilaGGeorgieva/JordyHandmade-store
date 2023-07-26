namespace JordyHandmade.Web.ViewModels.Order
{
    using System.Collections.Generic;

    public class MyOrderDetailsViewModel : MyOrdersViewModel
    {
        public IEnumerable<OrderedProductViewModel> OrderedProducts { get; set; } = null!;
    }
}
