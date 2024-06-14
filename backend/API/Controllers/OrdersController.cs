using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders([FromQuery] string name)
        {
            return await _orderService.GetOrdersByName(name);
        }

        [HttpPost("{orderId}/checkout")]
        public async Task<ActionResult<Order>> CheckoutOrder(Guid orderId)
        {
            try
            {
                var order = await _orderService.CheckoutOrder(orderId);
                return Ok(order);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}