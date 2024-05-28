using Exoticamp.UI.Models.Banners;
using Exoticamp.UI.Models.ResponseModels.Banners;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IBannerRepository
    {
        Task<IEnumerable<BannerViewModel>> GetAllBanners();

        Task<CreateBannerResponseModel> AddBanners(BannerViewModel model);

        Task<GetByIdResponseModel> GetBannerById(string id);
        Task<EditBannerResponseModel> EditBanner(BannerViewModel bannerVM);

        Task<DeleteBannerResponseModel> DeleteBanner(string Id);
    }
}
