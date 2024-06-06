using Exoticamp.UI.Models.Registration;
using Exoticamp.UI.Models.ResponseModels.Events;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IRegistrationRepository
    {
        Task<CreateRegistrationUsResponse> CreateRegistration(RegistrationVM   registrationVM);
        Task<CreateRegistrationUsResponse> CreateVendorRegistration(RegistrationVM registrationVM);
         
    }
}
 