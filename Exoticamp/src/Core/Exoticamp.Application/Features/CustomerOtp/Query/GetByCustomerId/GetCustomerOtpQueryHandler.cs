//using AutoMapper;
//using Exoticamp.Application.Contracts.Persistence;
//using Exoticamp.Application.Exceptions;
//using Exoticamp.Application.Features.Campsite.Query.GetCampsite;
//using Exoticamp.Application.Responses;
//using MediatR;
//using Microsoft.AspNetCore.DataProtection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Exoticamp.Application.Features.CustomerOtp.Query.GetByCustomerId
//{
//	internal class GetCustomerOtpQueryHandler : IRequestHandler<GetCustomerOtpQuery, Response<CustomerOtpVM>>
//	{
//		private readonly IAsyncRepository<Domain.Entities.CustomerOtp> _customerOtpRepository;
//		private readonly IMapper _mapper;

//		private readonly IDataProtector _protector;
//		public GetCustomerOtpQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.CustomerOtp> customerOtpRepository, IDataProtectionProvider provider)
//		{
//			_mapper = mapper;

//			_customerOtpRepository = customerOtpRepository;

//		}
//		public async Task<Response<CustomerOtpVM>> Handle(GetCustomerOtpQuery request, CancellationToken cancellationToken)
//		{
//			// Retrieve the campsite by ID
//			var campsite = await _customerOtpRepository.GetByIdAsync(request.Id);

//			// Check if the campsite is null or not active
//			if (campsite == null || !campsite.isActive == true)
//			{
//				throw new NotFoundException(nameof(Domain.Entities.Campsite), request.Id);
//			}

//			// Map the campsite to the view model
//			var campsiteDto = _mapper.Map<CampsiteVM>(campsite);

//			// Create the response object
//			var response = new Response<CampsiteVM>(campsiteDto);

//			return response;
//		}
//	}
//}
