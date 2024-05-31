using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface ICampsiteDetailsRepository : IAsyncRepository<CampsiteDetails>
    {
        Task<List<CampsiteDetails>> GetAllCampsite(bool includePassedEvents);
        Task<CampsiteDetails> AddCampsite(CampsiteDetails campsiteDetails);
        Task<CampsiteDetails> Update(CampsiteDetails campsiteDetails);
        Task<CampsiteDetails> Delete(CampsiteDetails campsiteDetails);
    }
}
