namespace JordyHandmade.Web.Areas.Admin.Controllers
{
	using JordyHandmade.Services.Data.Interfaces;
	using JordyHandmade.Services.Data.Models;
	using JordyHandmade.Web.ViewModels.Order;
	using Microsoft.AspNetCore.Mvc;

	public class OrderController : BaseAdminController
	{
		private readonly IOrderService orderService;
		private readonly ICustomerService customerService;
		private readonly ITownService townService;

		public OrderController(IOrderService orderService, ICustomerService customerService, ITownService townService)
		{
			this.orderService = orderService;
			this.customerService = customerService;
			this.townService = townService;
		}

		public async Task<IActionResult> All([FromQuery]AllOrdersQueryModel queryModel)
		{
			AllOrdersServiceModel serviceModel =
				await orderService.GetAllAsync(queryModel);

			queryModel.Orders = serviceModel.AllOrders;
			queryModel.TotalOrdersCount = serviceModel.TotalOrdersCount;
			queryModel.Towns = await this.townService.GetAllTownNamesAsync();
			queryModel.Customers = await this.customerService.GetAllCustomerNamesAsync();
			queryModel.StatusTypes = this.orderService.GetAllStatusTypes(); 

			return View(queryModel);
		}
	}
}
