 namespace JordyHandmade.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Product;
    using JordyHandmade.Web.Infrastructure.Extensions;
    using static JordyHandmade.Common.NotificationMessagesConstants;

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
            bool productExists = await this.productService.ExistsByIdAsync(id);

            if (!productExists) 
            {
                TempData[ErrorMessage] = "Product with the provided id does not exist!";

                return RedirectToAction("All");
            }

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
    }
}
