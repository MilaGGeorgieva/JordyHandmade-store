﻿using JordyHandmade.Web.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordyHandmade.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task AddToOrderAsync(string customerId, OrderFormModel orderModel);

        Task<IEnumerable<OrderStatusViewModel>> GetOrderStatusAsync(string customerId); 
    }
}