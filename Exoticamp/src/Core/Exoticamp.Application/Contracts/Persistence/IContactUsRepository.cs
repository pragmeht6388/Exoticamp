using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface IContactUsRepository : IAsyncRepository<ContactUs>
    {
        Task<List<ContactUs>> GetAllContactUs(bool includePassedEvents);
        Task<ContactUs> AddContactUs(ContactUs contactUs);
        //Task<ContactUs> Update(ContactUs contactUs);
        //Task<ContactUs> Delete(ContactUs contactUs);
    }
}
