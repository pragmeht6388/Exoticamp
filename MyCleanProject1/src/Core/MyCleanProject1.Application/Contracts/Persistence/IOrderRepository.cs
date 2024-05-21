using MyCleanProject1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Contracts.Persistence
{
    public interface IOrderRepository: IAsyncRepository<Order>
    {
        Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size);
        Task<int> GetTotalCountOfOrdersForMonth(DateTime date);
    }
}
