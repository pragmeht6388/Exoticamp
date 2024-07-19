using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerConsents.Command.AddCustomerConsent
{
    public class CustomerConsentCommand : IRequest<Response<CustomerConsentDto>>
    {

        public int CustomerId { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
       
    }
}
