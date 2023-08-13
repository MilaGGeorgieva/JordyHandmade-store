namespace JordyHandmade.Web.ViewModels.Order
{
	public class OrderAllViewModel : MyOrdersViewModel 
	{
		//[DataType(DataType.DateTime)]
		//[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
		public string? EndDate { get; set; }

		public string CustomerId { get; set; } = null!;

		public string CustomerName { get; set; } = null!;

		public string TownName { get; set; } = null!;
	}
}
