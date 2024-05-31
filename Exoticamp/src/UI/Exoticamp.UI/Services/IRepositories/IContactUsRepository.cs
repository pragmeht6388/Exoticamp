using Exoticamp.UI.Models.ContactUs;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels.ContactUs;
using Microsoft.VisualStudio.Services.WebApi;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IContactUsRepository
    {
        Task<IEnumerable<ContactUsVM>> GetAllContacts();
        Task<CreateContactUsResponse> AddContact(ContactUsVM contactUsVM);

        //Task<IPagedList<ContactUsVM>> GetPagedContactsAsync(int pageNumber, int pageSize);

    }
}
