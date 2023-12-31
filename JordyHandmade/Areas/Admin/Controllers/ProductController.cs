﻿namespace JordyHandmade.Web.Areas.Admin.Controllers
{	
	using Microsoft.AspNetCore.Mvc;

	using JordyHandmade.Services.Data.Interfaces;
	using JordyHandmade.Web.Infrastructure.Extensions;
	using JordyHandmade.Web.ViewModels.Product;
	using static JordyHandmade.Common.NotificationMessagesConstants;

	public class ProductController : BaseAdminController
	{
		private readonly IProductService productService;
		private readonly ICategoryService categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			this.productService = productService;
			this.categoryService = categoryService;
		}

		public async Task<IActionResult> Add()
		{
			ProductFormModel productForm = new ProductFormModel()
			{
				Categories = await this.categoryService.GetAllCategoriesForSelectAsync(),
			};

			return View(productForm);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductFormModel productForm)
		{
			bool categoryExists = await this.categoryService.ExistsByIdAsync(productForm.CategoryId);

			if (!categoryExists)
			{
				ModelState.AddModelError(nameof(productForm.CategoryId), "Entered category does not exist!");
				productForm.Categories = await this.categoryService.GetAllCategoriesForSelectAsync();
				return View(productForm);
			}

			if (!ModelState.IsValid)
			{
				productForm.Categories = await this.categoryService.GetAllCategoriesForSelectAsync();
				return View(productForm);
			}

			try
			{
				await this.productService.AddProductAsync(productForm);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error ocurred while adding current product.");
				productForm.Categories = await this.categoryService.GetAllCategoriesForSelectAsync();
				return View(productForm);
			}

			return this.RedirectToAction("All", "Product", new { area = "" });
		}

		public async Task<IActionResult> Edit(string id)
		{
			bool productExists = await this.productService.ExistsByIdAsync(id);

			if (!productExists)
			{
				TempData[ErrorMessage] = "Product with the provided id does not exist!";

				return RedirectToAction("All", "Product", new { area = "" });
			}

			try
			{
				ProductFormModel editModel = await this.productService.GetProductToEditAsync(id);
				editModel.Categories = await this.categoryService.GetAllCategoriesForSelectAsync();

				return View(editModel);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(string id, ProductFormModel editModel)
		{			
			if (!ModelState.IsValid)
			{
				editModel.Categories = await this.categoryService.GetAllCategoriesForSelectAsync();
				return View(editModel);
			}

			bool productExists = await this.productService.ExistsByIdAsync(id);

			if (!productExists)
			{
				TempData[ErrorMessage] = "Product with the provided id does not exist and cannot be edited!";

				return RedirectToAction("All", "Product", new { area = "" });
			}

			bool categoryExists = await this.categoryService.ExistsByIdAsync(editModel.CategoryId);

			if (!categoryExists)
			{
				ModelState.AddModelError(nameof(editModel.CategoryId), "Entered category does not exist!");
				editModel.Categories = await this.categoryService.GetAllCategoriesForSelectAsync();
				return View(editModel);
			}

			try
			{
				await this.productService.UpdateAsync(id, editModel);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error ocurred while updating selected product. Please try again later!");
				editModel.Categories = await this.categoryService.GetAllCategoriesForSelectAsync();
				return View(editModel);
			}

			TempData[SuccessMessage] = "Selected product was edited successfully!";
			return RedirectToAction("Details", "Product", new { id, area = "" });
		}

		public async Task<IActionResult> Delete(string id)
		{
			bool productExists = await this.productService.ExistsByIdAsync(id);

			if (!productExists)
			{
				TempData[ErrorMessage] = "Product with the provided id does not exist!";

				return RedirectToAction("All", "Product", new { area = "" });
			}

			try
			{
				AllViewModel viewModel = await this.productService.GetProductToDeleteAsync(id);

				return View(viewModel);

			}
			catch (Exception)
			{
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id, AllViewModel viewModel)
		{
			bool productExists = await this.productService.ExistsByIdAsync(id);

			if (!productExists)
			{
				TempData[ErrorMessage] = "Product with the provided id does not exist!";

				return RedirectToAction("All", "Product", new { area = "" });
			}

			try
			{
				await this.productService.DeleteAsync(id);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while deleting selected product!");
				return View(viewModel);
			}

			TempData[SuccessMessage] = "Selected product was deleted successfully!";
			return RedirectToAction("All", "Product", new { area = "" });
		}
	}
}
