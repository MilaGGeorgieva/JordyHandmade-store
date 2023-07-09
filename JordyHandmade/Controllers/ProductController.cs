using JordyHandmade.Services.Data.Interfaces;
using JordyHandmade.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace JordyHandmade.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllViewModel> allProducts = 
                await this.productService.GetAllAsync();

            return View(allProducts);
        }
    }
}
