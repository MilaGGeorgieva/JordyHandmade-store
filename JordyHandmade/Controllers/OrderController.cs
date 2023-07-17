namespace JordyHandmade.Web.Controllers
{    
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using JordyHandmade.Web.Infrastructure.Extensions;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Order;

    [Authorize]
    public class OrderController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public OrderController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }
        
        public async Task<IActionResult> BuyProduct(string id)
        {
            bool productExists = await this.productService.ExistsByIdAsync(id);
            int quantityAvailable = await this.productService.GetQuantityInStockByIdAsync(id);

            if (!productExists) 
            {
                return this.RedirectToAction("All", "Product");
            }

            if (quantityAvailable == 0)
            {
                return this.RedirectToAction("All", "Product");
            }  

            try
            {
                OrderFormModel orderModel = new OrderFormModel();
                orderModel.ProductToBuy = await this.productService.GetDetailsAsync(id);

                return View(orderModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }           
        }

        [HttpPost]
        public async Task<IActionResult> BuyProduct(OrderFormModel orderModel) 
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(orderModel.Quantity), "This product quantity is not correct!");
                return View(orderModel);
            }

            int quantityAvailable = await this.productService.GetQuantityInStockByIdAsync(orderModel.ProductToBuy.Id);

            if (orderModel.Quantity > quantityAvailable)
            {
                ModelState.AddModelError(nameof(orderModel.Quantity), "This product quantity is not available!");
                return View(orderModel);
            }

            string currentUserId = this.User.GetUserId();

            try
            {
                await this.orderService.AddToOrderAsync(currentUserId, orderModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding this product to your order!");
                return View(orderModel);
            }

            return RedirectToAction("OrderStatus");
        }

        public async Task<IActionResult> OrderStatus() 
        {
            string currentUserId = this.User.GetUserId();

            IEnumerable<OrderStatusViewModel> orderStatus = 
                await this.orderService.GetOrderStatusAsync(currentUserId);

            return this.View(orderStatus);
        }
    }
}
