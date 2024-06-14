using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(Order order);
    }
}