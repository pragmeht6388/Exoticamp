using Exoticamp.UI.Models.Registration;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Vendors;
using Exoticamp.UI.Models.Vendors;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IVendorRepository
    {
        Task<Response<VendorVM>> GetVendorByIdAsync(string UserId);
        Task<Response<VendorResponse>> UpdateVendorProfileAsync(VendorVM vendor);
    }
}
