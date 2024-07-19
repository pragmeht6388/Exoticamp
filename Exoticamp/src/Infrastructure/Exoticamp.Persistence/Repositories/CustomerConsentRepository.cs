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
    public class CustomerConsentRepository : BaseRepository<CustomerConsent>,ICustomerConsentRepository
    {
        private readonly ILogger _logger;
        public CustomerConsentRepository(ApplicationDbContext dbContext, ILogger<CustomerConsent> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
    }
}
