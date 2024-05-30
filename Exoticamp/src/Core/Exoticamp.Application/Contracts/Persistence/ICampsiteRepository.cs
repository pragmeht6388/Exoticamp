using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface ICampsiteRepository : IAsyncRepository<Campsite>
    {
        Task<List<Campsite>> GetAllCampsite(bool includePassedEvents);
        Task<Campsite> AddCampsite(Campsite campsite);
        Task<Campsite> Update(Campsite campsite);
        Task<Campsite> Delete(Campsite campsite);
    }
}
