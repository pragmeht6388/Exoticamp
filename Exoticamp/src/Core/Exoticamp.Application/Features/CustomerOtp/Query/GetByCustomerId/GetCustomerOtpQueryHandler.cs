using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Campsite.Query.GetCampsite;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerOtp.Query.GetByCustomerId
{
	internal class GetCustomerOtpQueryHandler : IRequestHandler<GetCustomerOtpQuery, Response<CustomerOtpVM>>
	{
		private readonly IAsyncRepository<Domain.Entities.CustomerOtp> _customerOtpRepository;
		private readonly IMapper _mapper;

		private readonly IDataProtector _protector;
		public GetCustomerOtpQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.CustomerOtp> customerOtpRepository, IDataProtectionProvider provider)
		{
			_mapper = mapper;

			_customerOtpRepository = customerOtpRepository;

		}
		public async Task<Response<CustomerOtpVM>> Handle(GetCustomerOtpQuery request, CancellationToken cancellationToken)
		{
			

			var customerOtp = await _customerOtpRepository.GetByIdbyintAsync(request.OtpId);

			if (customerOtp == null )
			{
				throw new NotFoundException(nameof(Domain.Entities.CustomerOtp), request.OtpId);
			}

			var customerOtpDto = _mapper.Map<CustomerOtpVM>(customerOtp);

			var response = new Response<CustomerOtpVM>(customerOtpDto);

			return response;
		}
	}
}
