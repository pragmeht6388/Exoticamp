using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Models.ResponseModels.Campsite;
using Exoticamp.UI.Models.ResponseModels.CampsiteDetails;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface ICampsiteDetailsRepository
    {
       Task<CreateCampsiteDetailsResponseModel> AddCampsiteDetails(CampsiteDetailsVM campsiteVM);
        Task<IEnumerable<CampsiteDetailsVM>> GetAllCampsites();

        Task<GetCampsiteDetailsByIdResponseModel> GetCampsiteById(string Id);

        //Task<CreateCampsiteDetailsResponseModel> EditCampsite(CampsiteDetailsVM campsiteVM);
        //Task<CreateCampsiteDetailsResponseModel> DeleteCampsite(string Id);
    }
}
