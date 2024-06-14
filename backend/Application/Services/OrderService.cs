using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderManagementContext _context;
        private readonly IPaymentService _paymentService;
        private readonly IEmailService _emailService;
        private readonly IProductionService _productionService;

        public OrderService(OrderManagementContext context, IPaymentService paymentService, IEmailService emailService, IProductionService productionService)
        {
            _context = context;
            _paymentService = paymentService;
            _emailService = emailService;
            _productionService = productionService;
        }

        public async Task<IEnumerable<Order>> GetOrdersByName(string name)
        {
            return await _context.Orders.Where(o => o.OrderName.Contains(name)).ToListAsync();
        }

        public async Task<Order> CheckoutOrder(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException("Order not found");
            }

            var paymentResult = await _paymentService.ProcessPayment(order);
            if (paymentResult)
            {
                order.OrderStatus = "PAID";
                _context.Update(order);
                await _context.SaveChangesAsync();

                await _emailService.SendEmail(order);
                await _productionService.UpdateOrderStatus(order);
            }
            else
            {
                order.OrderStatus = "FAILED";
                _context.Update(order);
                await _context.SaveChangesAsync();
            }

            return order;
        }
    }
}