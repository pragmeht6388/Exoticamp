using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerOtp.Commands.AddCustomerOtp
{
	internal class AddCustomerOtpCommandHandler : IRequestHandler<AddCustomerOtpCommand, Response<CustomerOtpDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICustomerOtpRepository _customerOtpRepository;
		private readonly IMessageRepository _messageRepository;

		public AddCustomerOtpCommandHandler(IMapper mapper, ICustomerOtpRepository customerOtpRepository, IMessageRepository messageRepository)
		{
			_mapper = mapper;
			_customerOtpRepository = customerOtpRepository;
			_messageRepository = messageRepository;
		}

		public async Task<Response<CustomerOtpDto>> Handle(AddCustomerOtpCommand request, CancellationToken cancellationToken)
        {
            Response<CustomerOtpDto> addCustomerOtpCommandResponse = null;

            var validator = new AddCustomerOtpCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var customerOtp = new Domain.Entities.CustomerOtp { CustomerID=request.CustomerID, CreatedBy=request.CreatedBy,CreatedDate=request.CreatedDate,OtpNo=request.OtpNo};
				customerOtp = await _customerOtpRepository.AddAsync(customerOtp);
				addCustomerOtpCommandResponse = new Response<CustomerOtpDto>(_mapper.Map<CustomerOtpDto>(customerOtp), "success");
            }

            return addCustomerOtpCommandResponse;

        }
	}
}
