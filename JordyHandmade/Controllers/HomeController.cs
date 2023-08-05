namespace JordyHandmade.Web.Controllers
{    
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using JordyHandmade.Web.ViewModels.Home;
    using JordyHandmade.Services.Data.Interfaces;
    using static JordyHandmade.Common.GeneralApplicationConstants;
    using JordyHandmade.Web.Infrastructure.Extensions;

    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsAdmin())
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }
            
            IEnumerable<IndexViewModel> viewModel = await this.productService.LastThreeProductsAsync();
            
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}