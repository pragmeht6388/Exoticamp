using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
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
    public class CustomerConsentHandler : IRequestHandler<CustomerConsentCommand, Response<CustomerConsentDto>>
    {

        private readonly IMapper _mapper;
        private readonly ICustomerConsentRepository _customerConsentRepository;
        private readonly IMessageRepository _messageRepository;

        public CustomerConsentHandler(IMapper mapper, ICustomerConsentRepository customerConsentRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _customerConsentRepository = customerConsentRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CustomerConsentDto>> Handle(CustomerConsentCommand request, CancellationToken cancellationToken)
        {
            Response<CustomerConsentDto> CustomerConsentCommandResponse = null;

                var customerConsentIp = _mapper.Map<CustomerConsent>(request);
            customerConsentIp.CreatedBy = "admin";
            customerConsentIp.CreatedDate = DateTime.Now;

                var result = await _customerConsentRepository.AddAsync(customerConsentIp);
                CustomerConsentCommandResponse = new Response<CustomerConsentDto>(_mapper.Map<CustomerConsentDto>(result), "success");
 

            return CustomerConsentCommandResponse;

        }
    }
}
