namespace JordyHandmade.Web.Controllers
{    
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using JordyHandmade.Web.Infrastructure.Extensions;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Order;
    using JordyHandmade.Web.ViewModels.Customer;
    using static JordyHandmade.Common.NotificationMessagesConstants;
    using JordyHandmade.Web.ViewModels.Product;

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
                TempData[ErrorMessage] = "Such product does not exist! Contact JordyHandmade!";
                return this.RedirectToAction("All", "Product");
            }

            if (quantityAvailable == 0)
            {
                TempData[ErrorMessage] = "Product is not available at the moment! Contact JordyHandmade!";
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

        public async Task<IActionResult> Edit(string id) 
        {
            bool productExists = await this.productService.ExistsByIdAsync(id);
            int quantityAvailable = await this.productService.GetQuantityInStockByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "Such product does not exist! Contact JordyHandmade!";
                return this.RedirectToAction("OrderStatus");
            }

            if (quantityAvailable == 0)
            {
                TempData[ErrorMessage] = "Product is not available at the moment! Contact JordyHandmade!";
                return this.RedirectToAction("All", "Product");
            }

            string currentCustomerId = this.User.GetUserId();
            string editedOrderId = await this.orderService.GetOrderCompilingId(currentCustomerId);
            
            try
            {
                OrderFormModel editModel = new OrderFormModel();
                editModel.ProductToBuy = await this.productService.GetDetailsAsync(id);
                editModel.Quantity = await this.orderService.GetProductQtyInOrderByIdsAsync(editedOrderId, id);
                return View(editModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, OrderFormModel editModel)
        {
            int quantityAvailable = await this.productService.GetQuantityInStockByIdAsync(id);

            if (editModel.Quantity > quantityAvailable)
            {
                ModelState.AddModelError(nameof(editModel.Quantity), "This product quantity is not available!");
                return View(editModel);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(editModel.Quantity), "This product quantity is not correct!");
                return View(editModel);
            }

            string currentCustomerId = this.User.GetUserId();
            string editedOrderId = await this.orderService.GetOrderCompilingId(currentCustomerId);

            try
            {
                await this.orderService.UpdateOrderAsync(editedOrderId, id, editModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while changing product quantity!");
                return View(editModel);
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

        public IActionResult DeliveryTerms()
        {
            return View();
        }

        public IActionResult ReturnPolicy()
        {
            return View();
        }

        public async Task<IActionResult> Delete(string id) 
        {
            bool orderExists = await this.orderService.OrderExistsByIdAsync(id);

            if (!orderExists) 
            {
                TempData[ErrorMessage] = "Order with the provided id does not exist!";
                
                return this.RedirectToAction("Mine");
            }

            string currentUserId = this.User.GetUserId();

            bool isCustomerOwner = await this.orderService.IsCustomerOwnerOfOrderByIdsAsync(currentUserId, id);

            if (!isCustomerOwner && !User.IsAdmin()) 
            {
                TempData[ErrorMessage] = "You are not the customer making this order and you can not delete it!";

                return this.RedirectToAction("Mine");
            }

            try
            {
                OrderStatusViewModel deleteModel = await this.orderService.GetOrderToDeleteAsync(id);

                return View(deleteModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred! Try again!";
                return RedirectToAction("Mine");                
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, OrderStatusViewModel deleteModel) 
        {
            bool orderExists = await this.orderService.OrderExistsByIdAsync(id);

            if (!orderExists)
            {
                TempData[ErrorMessage] = "Order with the provided id does not exist!";

                return this.RedirectToAction("Mine");
            }

            string currentUserId = this.User.GetUserId();

            bool isCustomerOwner = await this.orderService.IsCustomerOwnerOfOrderByIdsAsync(currentUserId, id);

            if (!isCustomerOwner && !User.IsAdmin())
            {
                TempData[ErrorMessage] = "You are not the customer making this order and you can not delete it!";

                return this.RedirectToAction("Mine");
            }

            try
            {
                await this.orderService.DeleteAsync(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while deleting selected order!");
                return View(deleteModel);
            }

            TempData[SuccessMessage] = "Selected order was deleted successfully!";
            return RedirectToAction("Mine");
        }

        public async Task<IActionResult> Mine() 
        {
            string currentUserId = this.User.GetUserId();

            IEnumerable<MyOrdersViewModel> myOrders = 
                await this.orderService.GetMyOrdersAsync(currentUserId);

            return View(myOrders);
        }

        public async Task<IActionResult> Details(string id) 
        {
            bool orderExists = await this.orderService.OrderExistsByIdAsync(id);

            if (!orderExists)
            {
                TempData[ErrorMessage] = "Order with the provided id does not exist!";

                return this.RedirectToAction("Mine");
            }

            try
            {
                OrderStatusViewModel detailsView = await this.orderService.GetOrderDetailsAsync(id);

                return View(detailsView);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred! Try again!";
                return this.RedirectToAction("Mine");
            }            
        }
    }
}
