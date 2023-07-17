namespace JordyHandmade.Services.Data.Services
{
    using Microsoft.EntityFrameworkCore;

    using JordyHandmade.Data;
    using JordyHandmade.Data.Models;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Order;
    using System.Collections.Generic;    

    public class OrderService : IOrderService
    {
        private readonly JordyHandmadeDbContext dbContext;

        public OrderService(JordyHandmadeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddToOrderAsync(string customerId, OrderFormModel orderModel)
        {
            bool orderExists = await this.dbContext
                .Orders.AnyAsync(o => o.CustomerId.ToString() == customerId && o.Status.ToString() == "Collecting");
            
            if (orderExists == false)
            {
                Order order = new Order()
                {
                    StartDate = DateTime.UtcNow,
                    Status = 0,
                    Discount = 0,
                    TotalAmount = 0,
                    CustomerId = Guid.Parse(customerId)
                };
                
                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();
            }

            var orderCompiling = await this.dbContext
                .Orders
                .Where(o => o.CustomerId.ToString() == customerId && o.Status.ToString() == "Collecting")
                .FirstAsync();

            bool productWasAdded = await this.dbContext
                .OrdersProducts.AnyAsync(op => op.OrderId == orderCompiling.Id && op.ProductId.ToString() == orderModel.ProductToBuy.Id);

            if (productWasAdded == false)
            {
                OrderProduct orderProduct = new OrderProduct()
                {
                    OrderId = orderCompiling.Id,
                    ProductId = Guid.Parse(orderModel.ProductToBuy.Id),
                    ProductQuantity = 0
                };

                await dbContext.OrdersProducts.AddAsync(orderProduct);
                await dbContext.SaveChangesAsync();
            }

            var orderProductCompiling = await this.dbContext
                .OrdersProducts
                .Where(op => op.OrderId == orderCompiling.Id && op.ProductId.ToString() == orderModel.ProductToBuy.Id)
                .FirstAsync();

            orderProductCompiling.ProductQuantity += orderModel.Quantity;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderStatusViewModel>> GetOrderStatusAsync(string customerId)
        {
            IEnumerable<OrderStatusViewModel> orderStatus = await this.dbContext
                .OrdersProducts
                .Where(op => op.Order.CustomerId.ToString() == customerId && op.Order.Status.ToString() == "Collecting")
                .Select(op => new OrderStatusViewModel() 
                {
                    ProductName = op.Product.Name,
                    Price = op.Product.Price,
                    ProductQuantity = op.ProductQuantity,
                    ProductTotal = op.Product.Price * op.ProductQuantity,
                    OrderTotal = op.Order.OrderProducts.Sum(x => x.ProductQuantity * x.Product.Price)
                })
                .ToArrayAsync();

            return orderStatus;
        }
    }
}
