using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(Order order);
    }
}