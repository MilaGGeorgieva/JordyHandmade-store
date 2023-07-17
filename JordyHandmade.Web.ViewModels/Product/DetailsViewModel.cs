namespace JordyHandmade.Web.ViewModels.Product
{
	public class DetailsViewModel : AllViewModel
	{		
		public string Description { get; set; } = null!;

		public int QuantityInStock { get; set; }
	}
}
