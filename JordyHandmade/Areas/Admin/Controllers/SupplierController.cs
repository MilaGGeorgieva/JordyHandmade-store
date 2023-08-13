namespace JordyHandmade.Web.Areas.Admin.Controllers
{
	using JordyHandmade.Services.Data.Interfaces;
	using JordyHandmade.Web.ViewModels.Product;
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

		//[HttpPost]
		//public async Task<IActionResult> Add(ProductFormModel productForm)
		//{	
				
		//public async Task<IActionResult> Add(SupplierFormModel supplierForm) 		
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return View(supplierForm);
		//	}

		//	try
		//	{

		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}
			
		//}

		//	try
		//	{
		//		await this.productService.AddProductAsync(productForm);
		//	}
		//	catch (Exception)
		//	{
		//		this.ModelState.AddModelError(string.Empty, "Unexpected error ocurred while adding current product.");
		//		productForm.Categories = await this.categoryService.GetAllCategoriesAsync();
		//		return View(productForm);
		//	}

		//	return this.RedirectToAction("All", "Product", new { area = "" });
		//}





	}
}
