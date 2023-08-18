namespace JordyHandmade.Web.ViewModels.Supplier
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class SupplierAllViewModel
	{
		public string Id { get; set; } = null!;

		public string SupplierName { get; set; } = null!;

		public string? Website { get; set; }

		public string? Email { get; set; }

		public string PhoneNumber { get; set; } = null!;

		public string TownName { get; set; } = null!;
	}
}
