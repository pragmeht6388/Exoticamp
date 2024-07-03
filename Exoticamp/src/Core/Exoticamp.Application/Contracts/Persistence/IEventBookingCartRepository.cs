using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface IEventBookingCartRepository : IAsyncRepository<EventBookingCart>
    {
        Task<List<EventBookingCart>> GetAllEventBookingCart(bool includePassedEvents);
        Task<EventBookingCart> AddEventBookingCart(EventBookingCart eventBookingCart);
        Task<EventBookingCart> Update(EventBookingCart eventBookingCart);
        Task<EventBookingCart> Delete(EventBookingCart eventBookingCart);
    }
}
