using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerConsents.Command.AddCustomerConsent
{
    public class CustomerConsentDto
    {

        public int ConsentId { get; set; }
        public int CustomerId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
