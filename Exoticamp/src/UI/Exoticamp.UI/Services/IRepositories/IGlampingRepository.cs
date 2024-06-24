using Exoticamp.UI.Models.Glamping;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Glamping;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IGlampingRepository
    {
        //Task<Response<GlampingVM>> GetGlampingByIdAsync( );
        Task<Response<IEnumerable<GlampingVM>>> GetGlampingListVAsync();
        //Task<Response<GlampingVM>> GetGlampingByIdAsync(string id);
        Task<GetGlampingResponseModel> GetGlampingByIdAsync(string id);
    }
}
