﻿namespace JordyHandmade.Web.Controllers
{
	using JordyHandmade.Services.Data.Interfaces;
	using JordyHandmade.Web.ViewModels.Category;
	using Microsoft.AspNetCore.Mvc;

	public class CategoryController : Controller
	{
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}
		
		public IActionResult Add()
		{
			CategoryFormModel inputModel = new CategoryFormModel();
			return View(inputModel);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CategoryFormModel inputModel) 
		{
			if (!ModelState.IsValid)
			{
				return View(inputModel);
			}

			try
			{
				await this.categoryService.AddCategoryAsync(inputModel);
			}
			catch (Exception)
			{
				return this.View(inputModel);
			}

			return this.RedirectToAction("Index", "Home");
			//return this.RedirectToAction("AdminPage", "Admin");
		}
	}
}
