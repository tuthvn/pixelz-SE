using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductionService
    {
        Task UpdateOrderStatus(Order order);
    }
}