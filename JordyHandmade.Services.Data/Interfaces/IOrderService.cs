namespace JordyHandmade.Services.Data.Interfaces
{
	using JordyHandmade.Web.ViewModels.Order;
    using JordyHandmade.Services.Data.Models;

	public interface IOrderService
    {
        Task<bool> OrderExistsByIdAsync(string id);

        Task<string> GetOrderCompilingId(string customerId);

        Task<bool> IsCustomerOwnerOfOrderByIdsAsync(string customerId, string orderId);

        Task AddToOrderAsync(string customerId, string productId, OrderFormModel orderModel);

        Task RemoveFromOrderAsync(string productId, string orderCompilingId);

        Task<OrderStatusViewModel> GetOrderStatusAsync(string customerId);

        Task FinalizeOrderAsync(string orderId);

        Task<OrderConfirmationViewModel> GetConfirmationInfoAsync(string orderId);

        Task<OrderStatusViewModel> GetOrderToDeleteAsync(string orderId);

        Task DeleteAsync(string orderId);

        Task<IEnumerable<MyOrdersViewModel>> GetMyOrdersAsync(string customerId);        

        Task<AllOrdersServiceModel> GetAllAsync(AllOrdersQueryModel queryModel);

        IEnumerable<string> GetAllStatusTypes();
    }
}
