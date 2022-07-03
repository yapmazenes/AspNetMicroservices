using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order, int>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
