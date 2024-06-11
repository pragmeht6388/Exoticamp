using Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
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
        Task<CampsiteDetails> AddCampsite(AddCampsiteDetailsCommand campsiteDetails);
        Task<CampsiteDetails> Update(CampsiteDetails campsiteDetails);
        Task<CampsiteDetails> Delete(CampsiteDetails campsiteDetails);

        Task<List<CampsiteDetailsVM>> GetAllCampsiteWithCategoryAndActivityDetails();
        Task<Application.Features.CampsiteDetails.Query.GetCampsiteDetails.CampsiteDetailsVM> GetCampsiteByIdWithCategoryAndActivityDetails(Guid campsiteId);

    }
}
