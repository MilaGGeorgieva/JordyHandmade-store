namespace JordyHandmade.Web.Areas.Admin.Controllers
{
	using JordyHandmade.Services.Data.Interfaces;
	using JordyHandmade.Web.ViewModels.Supplier;
	using Microsoft.AspNetCore.Mvc;

	public class SupplierController : BaseAdminController
	{
		private readonly ISupplierService supplierService;

		public SupplierController(ISupplierService supplierService)
		{
			this.supplierService = supplierService;
		}
		
		public async Task<IActionResult> All()
		{
			return View();
		}		

		public IActionResult Add() 
		{
			try
			{
				SupplierFormModel supplierForm = new SupplierFormModel();

				return View(supplierForm);
			}
			catch (Exception)
			{
				return BadRequest();				
			}
			
		}

		[HttpPost]
		public async Task<IActionResult> Add(SupplierFormModel supplierForm)
		{
			if (!ModelState.IsValid)
			{
				return View(supplierForm);
			}

			try
			{
				await this.supplierService.AddSupplierAsync(supplierForm);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error ocurred while adding current supplier.");
				return View(supplierForm);
			}

			return this.RedirectToAction("All", "Supplier");
		}			

		//	return this.RedirectToAction("All", "Product", new { area = "" });

	}
}
