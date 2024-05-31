using Exoticamp.UI.Models.Campsite;
using Exoticamp.UI.Models.ContactUs;
using Exoticamp.UI.Models.ResponseModels.Campsite;
using Exoticamp.UI.Models.ResponseModels.ContactUs;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface ICampsiteRepository
    {
        Task<CreateCampsiteResponseModel> AddCampsite(CampsiteVM campsiteVM);
        Task<IEnumerable<CampsiteVM>> GetAllCampsites();
     
        Task<GetCampsiteByIdResponseModel> GetCampsiteById(string Id);

        Task<EditCampsiteResponseModel> EditCampsite(CampsiteVM campsiteVM);
        Task<DeleteCampsiteResponseModel> DeleteCampsite(string Id);
    }
}
