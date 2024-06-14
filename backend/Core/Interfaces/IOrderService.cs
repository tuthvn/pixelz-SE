using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersByName(string name);
        Task<Order> CheckoutOrder(Guid orderId);
    }
}