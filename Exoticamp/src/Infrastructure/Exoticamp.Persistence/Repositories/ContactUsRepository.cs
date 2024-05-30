using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Persistence.Repositories
{
    public class ContactUsRepository : BaseRepository<ContactUs>, IContactUsRepository
    {
        private readonly ILogger _logger;
        public ContactUsRepository(ApplicationDbContext dbContext, ILogger<ContactUs> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }



        public Task<ContactUs> AddContactUs(ContactUs product)
        {
            throw new NotImplementedException();
        }

       


        public Task<List<ContactUs>> GetAllContactUs(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }

       


    }
}
