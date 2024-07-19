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
	public class CustomerOtpRepository : BaseRepository<CustomerOtp>, ICustomerOtpRepository
	{
		private readonly ILogger _logger;
		public CustomerOtpRepository(ApplicationDbContext dbContext, ILogger<CustomerOtp> logger) : base(dbContext, logger)
		{
			_logger = logger;
		}

		public Task<CustomerOtp> AddCustomerOtp(CustomerOtp customerOtp)
		{
			throw new NotImplementedException();
		}
	}
}
