namespace JordyHandmade.Services.Data.Models
{
	using System.Collections.Generic;

	using JordyHandmade.Web.ViewModels.Order;

	public class AllOrdersServiceModel
	{
		public AllOrdersServiceModel()
		{
			AllOrders = new HashSet<OrderAllViewModel>();
		}
		
		public int TotalOrdersCount { get; set; }

		public IEnumerable<OrderAllViewModel> AllOrders { get; set; }
	}
}
