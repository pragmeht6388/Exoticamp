using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Customer.Commands.CreateCustomer;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<CreateCustomerDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreateCustomerDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Response<CreateCustomerDTO> addCustomerCommandResponse = new Response<CreateCustomerDTO>();

            // Validate the request
            var validator = new CreateCustomerCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            // Check if a customer with the given IC number already exists
            var existingCustomer = await _customerRepository.GetByIdbyintAsync(request.ICNumber);
            if (existingCustomer != null)
            {
                addCustomerCommandResponse.Message = "Customer with the given IC number already exists.";
                return addCustomerCommandResponse;
            }

            Random random = new Random();
            var customer = new Domain.Entities.Customer
            {
                MobileNumber = request.MobileNumber,
                CreatedDate = request.CreatedDate,
                OTPNO =  random.Next(1, 101),
                CreatedBy = request.CreatedBy,
                ICNumber = request.ICNumber
            };

            customer = await _customerRepository.AddCustomer(customer);
            var customerDto = _mapper.Map<CreateCustomerDTO>(customer);
            addCustomerCommandResponse = new Response<CreateCustomerDTO>(customerDto, "Customer created successfully");

            return addCustomerCommandResponse;
        }
    }
}
