namespace JordyHandmade.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class SupplierController : BaseAdminController
	{
		public async Task<IActionResult> All()
		{
			return View();
		}
	}
}
