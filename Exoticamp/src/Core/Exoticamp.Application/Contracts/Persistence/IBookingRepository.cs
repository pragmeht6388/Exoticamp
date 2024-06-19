using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface IBookingRepository: IAsyncRepository<Booking>
    {
        public Task<bool> IsCheckInDateUnique(DateTime checkInDate);
    }
}
