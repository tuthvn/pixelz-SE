using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class MockPaymentService : IPaymentService
    {
        public Task<bool> ProcessPayment(Order order)
        {
            // Simulate payment processing
            return Task.FromResult(true);
        }
    }
}