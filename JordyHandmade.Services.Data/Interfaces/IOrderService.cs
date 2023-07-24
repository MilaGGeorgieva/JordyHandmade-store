using JordyHandmade.Web.ViewModels.Customer;
using JordyHandmade.Web.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordyHandmade.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<bool> OrderExistsByIdAsync(string id);

        Task<string> GetOrderCompilingId(string customerId);

        Task AddToOrderAsync(string customerId, string productId, OrderFormModel orderModel);

        Task RemoveFromOrderAsync(string productId, string orderCompilingId);

        Task<OrderStatusViewModel> GetOrderStatusAsync(string customerId);

        Task FinalizeOrderAsync(string orderId, OrderFinalizeViewModel finalModel);        
    }
}
