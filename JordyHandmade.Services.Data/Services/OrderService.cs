namespace JordyHandmade.Services.Data.Services
{
    using Microsoft.EntityFrameworkCore;

    using JordyHandmade.Data;
    using JordyHandmade.Data.Models;
    using JordyHandmade.Services.Data.Interfaces;
    using JordyHandmade.Web.ViewModels.Order;
    using System.Collections.Generic;
    using JordyHandmade.Data.Models.Enums;
    using JordyHandmade.Web.ViewModels.Customer;
    using System.Net.WebSockets;
	using JordyHandmade.Services.Data.Models;
    using JordyHandmade.Web.ViewModels.Order.Enums;

    public class OrderService : IOrderService
    {
        private readonly JordyHandmadeDbContext dbContext;

        public OrderService(JordyHandmadeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }        

        public async Task AddToOrderAsync(string customerId, string productId, OrderFormModel orderModel)
        {
            bool orderExists = await this.dbContext
                .Orders.AnyAsync(o => o.CustomerId.ToString() == customerId && o.Status == OrderStatus.Collecting);
            
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
                .Where(o => o.CustomerId.ToString() == customerId && o.Status == OrderStatus.Collecting)
                .FirstAsync();

            bool productWasAdded = await this.dbContext
                .OrdersProducts.AnyAsync(op => op.OrderId == orderCompiling.Id && op.ProductId.ToString() == productId);

            if (productWasAdded == false)
            {
                OrderProduct orderProduct = new OrderProduct()
                {
                    OrderId = orderCompiling.Id,
                    ProductId = Guid.Parse(productId),
                    ProductQuantity = 0
                };

                await dbContext.OrdersProducts.AddAsync(orderProduct);
                await dbContext.SaveChangesAsync();
            }

            var orderProductCompiling = await this.dbContext
                .OrdersProducts
                .Where(op => op.OrderId == orderCompiling.Id && op.ProductId.ToString() == productId)
                .FirstAsync();

            orderProductCompiling.ProductQuantity += orderModel.Quantity;
            await dbContext.SaveChangesAsync();
        }        

        public async Task<OrderStatusViewModel> GetOrderStatusAsync(string customerId)
        {
            var orderedProducts = await this.dbContext
                .OrdersProducts
                .Where(op => op.Order.CustomerId.ToString() == customerId && op.Order.Status == OrderStatus.Collecting)
                .Select(op => new OrderedProductViewModel() 
                {
                    ProductId = op.ProductId.ToString(),
                    ProductName = op.Product.Name,
                    Price = op.Product.Price,
                    ProductQuantity = op.ProductQuantity,
                    ProductTotal = op.Product.Price * op.ProductQuantity,                    
                })
                .ToArrayAsync();

            var orderCompiling = await this.dbContext
                .Orders
                .Where(o => o.CustomerId.ToString() == customerId && o.Status == OrderStatus.Collecting)
                .FirstAsync();

            var orderDate = orderCompiling.StartDate.ToString("yyyy-MM-dd H:mm");
            var orderId = orderCompiling.Id.ToString();     
            
            OrderStatusViewModel orderStatus = new OrderStatusViewModel() 
            {
                OrderId = orderId,
                OrderedProducts = orderedProducts,
                OrderTotal = orderedProducts.Sum(x => x.ProductQuantity * x.Price),
                StartDate = orderDate
            };             
            
            return orderStatus;
        }

        public async Task<bool> OrderExistsByIdAsync(string id)
        {
            bool result = await this.dbContext
                .Orders
                .AnyAsync(o => o.Id.ToString() == id);

            return result;
        }

        public async Task FinalizeOrderAsync(string orderId)
        {
            Order orderFinalized = await this.dbContext
                .Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Where(o => o.Id.ToString() == orderId)
                .FirstAsync();

            orderFinalized.Status = OrderStatus.ToBeSent;
            orderFinalized.TotalAmount = orderFinalized.OrderProducts.Sum(x => x.ProductQuantity * x.Product.Price);
            

            foreach (var product in orderFinalized.OrderProducts)
            {
                var orderedQty = product.ProductQuantity;                                              
                
                product.Product.QuantityInStock -= orderedQty;  
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveFromOrderAsync(string productId, string orderCompilingId)
        {
            var productToRemove = await this.dbContext
                .OrdersProducts
                .FirstAsync(op => op.OrderId.ToString() == orderCompilingId && op.ProductId.ToString() == productId);

            dbContext.OrdersProducts.Remove(productToRemove);
            await dbContext.SaveChangesAsync();
        }

        public async Task<string> GetOrderCompilingId(string customerId)
        {
            var orderCompiling = await this.dbContext
                .Orders
                .Where(o => o.CustomerId.ToString() == customerId && o.Status == OrderStatus.Collecting)
                .FirstAsync();

            return orderCompiling.Id.ToString();
        }

        public async Task<IEnumerable<MyOrdersViewModel>> GetMyOrdersAsync(string customerId)
        {
            IEnumerable<MyOrdersViewModel> myOrders = await this.dbContext
                .Orders
                .Where(o => o.CustomerId.ToString() == customerId)
                .Select(o => new MyOrdersViewModel()
                {
                    Id = o.Id.ToString(),
                    StartDate = o.StartDate.ToString("yyyy-MM-dd H:mm"),
                    Status = o.Status.ToString(),
                    Discount = o.Discount,
                    TotalAmount = o.TotalAmount
                })
                .ToArrayAsync();

            return myOrders;
        }

		public async Task<OrderConfirmationViewModel> GetConfirmationInfoAsync(string orderId)
		{			
			OrderConfirmationViewModel confirmationInfo = await this.dbContext
                .Orders              
                .Select(o => new OrderConfirmationViewModel() 
                {
                    OrderId = o.Id.ToString(),
                    OrderTotal = o.TotalAmount,
                    StartDate = o.StartDate.ToString("yyyy-MM-dd H:mm")
                })
                .FirstAsync(o => o.OrderId == orderId);

            return confirmationInfo; 
		}

		public Task<AllOrdersServiceModel> GetAllAsync(AllOrdersQueryModel queryModel)
		{
            IQueryable<Order> ordersQuery = dbContext
                .Orders
                .Include(o => o.Customer)
                .ThenInclude(c => c.Address)
                .ThenInclude(a => a.Town)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Status))
            {
                ordersQuery = ordersQuery
                    .Where(o => o.Status.ToString() == queryModel.Status);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.CustomerName))
            {
                ordersQuery = ordersQuery
                    .Where(o => o.Customer.CustomerName == queryModel.CustomerName);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.TownName))
            {
                ordersQuery = ordersQuery
                    .Where(o => o.Customer.Address.Town.TownName == queryModel.TownName);
            }

            ordersQuery = queryModel.OrderSorting switch
            {
                OrderSorting.Newest => ordersQuery
                    .OrderByDescending(o => o.StartDate),
                OrderSorting.Oldest => ordersQuery
                    .OrderBy(o => o.StartDate),
                OrderSorting.TotalAmountAscending => ordersQuery
                    .OrderBy(o => o.TotalAmount),
                OrderSorting.TotalAmountDescending => ordersQuery
                    .OrderByDescending(o => o.TotalAmount),
                _ => ordersQuery
                    .OrderByDescending(o => o.StartDate)
            };

		}
	}
}
