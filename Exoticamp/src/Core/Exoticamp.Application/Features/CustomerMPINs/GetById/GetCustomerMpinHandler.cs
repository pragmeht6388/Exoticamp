using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.CustomerOtp.Query.GetByCustomerId;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerMPINs.GetById
{
    internal class GetCustomerMpinHandler : IRequestHandler<GetCustomerMpinQuery, Response<GetCustomerMpinVM>>
    {
        private readonly IAsyncRepository<Domain.Entities.CustomerMPIN> _customerOtpRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetCustomerMpinHandler(IMapper mapper, IAsyncRepository<Domain.Entities.CustomerMPIN> customerOtpRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;

            _customerOtpRepository = customerOtpRepository;

        }
        public async Task<Response<GetCustomerMpinVM>> Handle(GetCustomerMpinQuery request, CancellationToken cancellationToken)
        {


            var customerOtp = await _customerOtpRepository.GetByIdbyintAsync(request.CustomerId);

            if (customerOtp == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.CustomerMPIN), request.CustomerId);
            }

            var customerOtpDto = _mapper.Map<GetCustomerMpinVM>(customerOtp);

            var response = new Response<GetCustomerMpinVM>(customerOtpDto);

            return response;
        }
    }
}
