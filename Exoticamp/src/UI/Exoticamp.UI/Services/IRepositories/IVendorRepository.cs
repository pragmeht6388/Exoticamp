using Exoticamp.UI.Models.Registration;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.Vendors;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IVendorRepository
    {
        public Task<Response<VendorVM>> GetVendorByIdAsync(string UserId);
        Task<Response<string>> UpdateVendorProfileAsync(VendorVM vendor);
    }
}
