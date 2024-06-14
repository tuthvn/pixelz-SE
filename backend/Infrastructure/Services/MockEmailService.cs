using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class MockEmailService : IEmailService
    {
        public Task SendEmail(Order order)
        {
            // Simulate sending email
            return Task.CompletedTask;
        }
    }
}