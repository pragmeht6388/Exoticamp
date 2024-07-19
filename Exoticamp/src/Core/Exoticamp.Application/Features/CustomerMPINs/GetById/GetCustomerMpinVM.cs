using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerMPINs.GetById
{
    public class GetCustomerMpinVM
    {
        public int PinId { get; set; }

        public int MPIN { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
    }
}
