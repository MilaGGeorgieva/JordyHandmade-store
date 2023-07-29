namespace JordyHandmade.Web.ViewModels.Order
{
    using System.Collections.Generic;

    public class OrderConfirmationViewModel
    {
		public string OrderId { get; set; } = null!;

		public decimal OrderTotal { get; set; }

		public string StartDate { get; set; } = null!;
	}
}
