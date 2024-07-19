using Exoticamp.Application.Features.Events.Queries.GetEventDetail;
using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface ICustomerRepository :IAsyncRepository<Customer>
    {
        Task<Customer> AddCustomer(Customer customer);
        //Task<Customer> GetCustomerByICId(int id);

    }
}
