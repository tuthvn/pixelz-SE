using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class MockProductionService : IProductionService
    {
        public Task UpdateOrderStatus(Order order)
        {
            // Simulate updating order status in production
            return Task.CompletedTask;
        }
    }
}