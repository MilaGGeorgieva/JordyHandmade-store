using JordyHandmade.Services.Data.Interfaces;
using JordyHandmade.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JordyHandmade.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllViewModel> allProducts = 
                await this.productService.GetAllAsync();

            return View(allProducts);
        }

        public async Task<IActionResult> Details(string id) 
        {
            try
            {
                DetailsViewModel detailsView = await this.productService.GetDetailsAsync(id);

                return View(detailsView);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All");                
            }            
        }

        public async Task<IActionResult> Add() 
        {
            ProductFormModel productForm = new ProductFormModel() 
            {
                Categories = await this.categoryService.GetAllCategoriesAsync(),
            };

            return View(productForm);        
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel productForm) 
        {
            //bool productExists = await this.productService.ExistsByIdAsync(productForm.Id);

            //if (productExists) 
            //{
                
            //}

            bool categoryExists = await this.categoryService.ExistsByIdAsync(productForm.CategoryId);

            if (!categoryExists) 
            {
                ModelState.AddModelError(nameof(productForm.CategoryId), "Entered category does not exist!");
                productForm.Categories = await this.categoryService.GetAllCategoriesAsync();
                return View(productForm);
            }

            if (!ModelState.IsValid)
            {
                productForm.Categories = await this.categoryService.GetAllCategoriesAsync();
                return View(productForm);
            }

            try
            {
                await this.productService.AddProductAsync(productForm);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error ocurred while adding current product.");
                productForm.Categories = await this.categoryService.GetAllCategoriesAsync();
                return View(productForm);
            }

            return this.RedirectToAction("All");
        }
    }
}
