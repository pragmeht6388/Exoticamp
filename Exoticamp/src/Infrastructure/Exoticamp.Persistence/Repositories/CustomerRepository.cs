using System;
using System.Threading.Tasks;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;

using Microsoft.Extensions.Logging;

namespace Exoticamp.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ILogger _logger;
        public CustomerRepository(ApplicationDbContext dbContext, ILogger<Customer> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }



        public async Task<Customer> AddCustomer(Customer customer)
        {
            // Add the customer entity to the DbSet
            await _dbContext.customers.AddAsync(customer);

            CustomerOtp customerOtp = new CustomerOtp();
            customerOtp.OtpNo = customer.OTPNO;
            customerOtp.CustomerID = customer.CustomerID;
            customerOtp.CreatedDate = customer.CreatedDate;
            customerOtp.CreatedBy = customer.CreatedBy;
            await _dbContext.customerOtps.AddAsync(customerOtp);



            // Save changes to the database
            await _dbContext.SaveChangesAsync();
            // Return the added customer entity
            return customer;
        }

       
    }
}

