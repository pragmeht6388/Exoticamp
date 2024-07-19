using Exoticamp.Application.Features.CustomerConsents.Command.AddCustomerConsent;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerMPINs.Commands.AddCustomerMPIN
{
    public class CustomerMPINCommand : IRequest<Response<CustomerMPINDto>>
    {
    
     
        public int MPIN { get; set; }
        public int CustomerId { get; set; }
    }
}
