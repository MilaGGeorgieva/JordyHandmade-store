namespace JordyHandmade.Web.ViewModels.Order
{
	using Enums;

	using static JordyHandmade.Common.GeneralApplicationConstants;
	
	public class AllOrdersQueryModel
	{
		public AllOrdersQueryModel()
		{
			CurrentPage = DefaultPage;
			OrdersPerPage = EntitiesPerPage;

			Customers = new HashSet<string>();
			Towns = new HashSet<string>();
			Orders = new HashSet<OrderAllViewModel>();
		}
		
		public string? Status { get; set; }		

		public string? CustomerName { get; set; }

		public string? TownName { get; set; }

		public OrderSorting OrderSorting { get; set; }

		public int CurrentPage { get; set; }

		public int OrdersPerPage { get; set; }

		public int TotalOrdersCount { get; set; }

		public IEnumerable<string> StatusTypes { get; set; }

		public IEnumerable<string> Customers { get; set; }

		public IEnumerable<string> Towns { get; set; }

		public IEnumerable<OrderAllViewModel> Orders { get; set; }
	}
}
