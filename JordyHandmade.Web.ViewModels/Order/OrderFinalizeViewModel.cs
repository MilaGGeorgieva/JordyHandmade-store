namespace JordyHandmade.Web.ViewModels.Order
{
	using JordyHandmade.Web.ViewModels.Customer;

	public class OrderFinalizeViewModel
	{
		public OrderStatusViewModel? OrderData { get; set; }

		public CustomerFormModel? CustomerData { get; set; }
	}
}
