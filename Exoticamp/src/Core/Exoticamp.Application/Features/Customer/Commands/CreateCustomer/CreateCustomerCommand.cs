using Exoticamp.Application.Features.Banners.Commands.CreateBanner;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Response<CreateCustomerDTO>>
    {
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OTPNO { get; set; }
        public string CreatedBy { get; set; }
        public int ICNumber { get; set; }

    }
}
