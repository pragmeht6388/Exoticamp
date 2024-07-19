using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerMPINs.Commands.AddCustomerMPIN
{
    public class CustomerMPINDto
    {
        public int PinId { get; set; }
 
        public int MPIN { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
    }
}
