namespace JordyHandmade.Web.Controllers
{    
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using JordyHandmade.Web.Infrastructure.Extensions;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Order;
    using JordyHandmade.Web.ViewModels.Customer;

    [Authorize]
    public class OrderController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;

        public OrderController(IProductService productService, IOrderService orderService, ICustomerService customerService)
        {
            this.productService = productService;
            this.orderService = orderService;
            this.customerService = customerService;
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
        public async Task<IActionResult> BuyProduct(string id, OrderFormModel orderModel) 
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(orderModel.Quantity), "This product quantity is not correct!");
                return View(orderModel);
            }

            int quantityAvailable = await this.productService.GetQuantityInStockByIdAsync(id);

            if (orderModel.Quantity > quantityAvailable)
            {
                ModelState.AddModelError(nameof(orderModel.Quantity), "This product quantity is not available!");
                return View(orderModel);
            }

            string currentUserId = this.User.GetUserId();

            try
            {
                await this.orderService.AddToOrderAsync(currentUserId, id, orderModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding this product to your order!");
                return View(orderModel);
            }

            return RedirectToAction("OrderStatus");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct(string id) 
        {
            string currentUserId = this.User.GetUserId();

            string orderCompilingId = await this.orderService.GetOrderCompilingId(currentUserId);

            await this.orderService.RemoveFromOrderAsync(id, orderCompilingId);

            return this.RedirectToAction("OrderStatus");
        }
        
        public async Task<IActionResult> OrderStatus() 
        {
            string currentUserId = this.User.GetUserId();

            OrderStatusViewModel orderStatus = 
                await this.orderService.GetOrderStatusAsync(currentUserId);

            return this.View(orderStatus);
        }

        public async Task<IActionResult> DeliveryData(string id) 
        {
            bool orderCompilingExists = await this.orderService.OrderExistsByIdAsync(id);

            if (!orderCompilingExists) 
            {
                return this.RedirectToAction("OrderStatus");
            }

            string currentUserId = this.User.GetUserId();

            try
            {
                CustomerFormModel deliveryModel = await this.customerService.GetCustomerToEditAsync(currentUserId);
                return View(deliveryModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost] 
        public async Task<IActionResult> DeliveryData(string id, CustomerFormModel deliveryModel) 
        {
            if (!ModelState.IsValid)
            {
                return this.View(deliveryModel);
            }
            
            string currentUserId = this.User.GetUserId();

            try
            {
                await this.customerService.AddCustomerDataAsync(currentUserId, deliveryModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding your delivery information!");
                return this.View(deliveryModel);
            }

            return this.RedirectToAction("Finalize", new { Id = id });
		}

        public async Task<IActionResult> Finalize(string id) 
        {
			bool orderCompilingExists = await this.orderService.OrderExistsByIdAsync(id);

			if (!orderCompilingExists)
			{
				return this.RedirectToAction("OrderStatus");
			}

			string currentUserId = this.User.GetUserId();

            try
            {
				OrderFinalizeViewModel finalModel = new OrderFinalizeViewModel()
				{
					OrderData = await this.orderService.GetOrderStatusAsync(currentUserId),
					CustomerData = await this.customerService.GetCustomerToEditAsync(currentUserId)
				};

                return this.View(finalModel);
			}
            catch (Exception)
            {
                return BadRequest();
            }           
		}

        [HttpPost]
        public async Task<IActionResult> Finalized(string id) 
        {                        
            await this.orderService.FinalizeOrderAsync(id);
            
            //ModelState.AddModelError(string.Empty, "Unexpected error occurred while finalizing your order! Please try again or contact administrator");
                
            
            return this.RedirectToAction("ConfirmationPage", new { Id = id });
        }

        public async Task<IActionResult> ConfirmationPage(string id) 
        {
            bool orderexists = await this.orderService.OrderExistsByIdAsync(id);

            if (!orderexists) 
            {
                return this.RedirectToAction("Finalize");
            }

            OrderConfirmationViewModel confirmaionModel = await this.orderService.GetConfirmationInfoAsync(id);
            return View(confirmaionModel);
        }

        public async Task<IActionResult> Mine() 
        {
            string currentUserId = this.User.GetUserId();

            IEnumerable<MyOrdersViewModel> myOrders = 
                await this.orderService.GetMyOrdersAsync(currentUserId);

            return View(myOrders);
        }
    }
}
