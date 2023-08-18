namespace JordyHandmade.Services.Data.Interfaces
{
	using JordyHandmade.Web.ViewModels.Order;
    using JordyHandmade.Services.Data.Models;

	public interface IOrderService
    {
        Task<bool> OrderExistsByIdAsync(string id);

        Task<string> GetOrderCompilingId(string customerId);

        Task<int> GetProductQtyInOrderByIdsAsync(string orderId, string productId);

        Task<bool> IsCustomerOwnerOfOrderByIdsAsync(string customerId, string orderId);

        Task AddToOrderAsync(string customerId, string productId, OrderFormModel orderModel);

        Task RemoveFromOrderAsync(string productId, string orderCompilingId);

        Task<OrderStatusViewModel> GetOrderStatusAsync(string customerId);

        Task<OrderStatusViewModel> GetOrderDetailsAsync(string orderId);

        Task UpdateOrderAsync(string orderId, string productId, OrderFormModel editModel);

        Task FinalizeOrderAsync(string orderId);

        Task<OrderConfirmationViewModel> GetConfirmationInfoAsync(string orderId);

        Task<OrderStatusViewModel> GetOrderToDeleteAsync(string orderId);

        Task DeleteAsync(string orderId);

        Task<IEnumerable<MyOrdersViewModel>> GetMyOrdersAsync(string customerId);        

        Task<AllOrdersServiceModel> GetAllAsync(AllOrdersQueryModel queryModel);

        IEnumerable<string> GetAllStatusTypes();
    }
}
