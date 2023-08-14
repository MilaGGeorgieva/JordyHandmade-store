namespace JordyHandmade.Services.Data.Interfaces
{
	using JordyHandmade.Web.ViewModels.Order;
    using JordyHandmade.Services.Data.Models;

	public interface IOrderService
    {
        Task<bool> OrderExistsByIdAsync(string id);

        Task<string> GetOrderCompilingId(string customerId);

        Task AddToOrderAsync(string customerId, string productId, OrderFormModel orderModel);

        Task RemoveFromOrderAsync(string productId, string orderCompilingId);

        Task<OrderStatusViewModel> GetOrderStatusAsync(string customerId);

        Task FinalizeOrderAsync(string orderId);

        Task<IEnumerable<MyOrdersViewModel>> GetMyOrdersAsync(string customerId);

        Task<OrderConfirmationViewModel> GetConfirmationInfoAsync(string orderId);

        Task<AllOrdersServiceModel> GetAllAsync(AllOrdersQueryModel queryModel);
    }
}
