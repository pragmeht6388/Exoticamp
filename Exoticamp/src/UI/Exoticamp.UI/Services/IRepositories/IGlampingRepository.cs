using Exoticamp.UI.Models.Glamping;
using Exoticamp.UI.Models.ResponseModels;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IGlampingRepository
    {
        Task<Response<GlampingVM>> GetGlampingListVAsync( );
    }
}
