using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.CustomerConsents.Command.AddCustomerConsent;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerMPINs.Commands.AddCustomerMPIN
{
 
        public class CustomerMPINHandler : IRequestHandler<CustomerMPINCommand, Response<CustomerMPINDto>>
        {

            private readonly IMapper _mapper;
            private readonly ICustomerMPINRepository _customerMPINRepository;
            private readonly IMessageRepository _messageRepository;

            public CustomerMPINHandler(IMapper mapper, ICustomerMPINRepository customerMPINRepository, IMessageRepository messageRepository)
            {
                _mapper = mapper;
                _customerMPINRepository = customerMPINRepository;
                _messageRepository = messageRepository;
            }

            public async Task<Response<CustomerMPINDto>> Handle(CustomerMPINCommand request, CancellationToken cancellationToken)
            {
                Response<CustomerMPINDto> CustomerConsentCommandResponse = null;

                var customerConsentIp = _mapper.Map<CustomerMPIN>(request);
                customerConsentIp.CreatedBy = "admin";
                customerConsentIp.CreatedDate = DateTime.Now;

                var result = await _customerMPINRepository.AddAsync(customerConsentIp);
                CustomerConsentCommandResponse = new Response<CustomerMPINDto>(_mapper.Map<CustomerMPINDto>(result), "success");


                return CustomerConsentCommandResponse;

            }
        
    }
}
