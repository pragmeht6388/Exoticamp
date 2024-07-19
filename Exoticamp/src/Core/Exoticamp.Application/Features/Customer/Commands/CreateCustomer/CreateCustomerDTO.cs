using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerDTO
    {
        public int CustomerID { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OTPNO { get; set; }
        public string CreatedBy { get; set; }
        public int ICNumber { get; set; }

        public virtual CustomerOtp CustomerOtp { get; set; }
    }
}
