using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Products.Commands.AddProduct;
using Exoticamp.Application.Models.Mail;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactUsEntity = Exoticamp.Domain.Entities.ContactUs;

namespace Exoticamp.Application.Features.ContactUs.Command.AddContactUs
{
    public class AddContactUsHandler : IRequestHandler<AddContactUsCommand, Response<ContactUsDto>>
    {

        private readonly IMapper _mapper;
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMessageRepository _messageRepository;

        public AddContactUsHandler(IMapper mapper, IContactUsRepository contactUsRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _contactUsRepository = contactUsRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<ContactUsDto>> Handle(AddContactUsCommand request, CancellationToken cancellationToken)
        {
            Response<ContactUsDto> addContactUsCommandResponse = null;

            var validator = new AddContactUsCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var contactUs = new ContactUsEntity { Name = request.Name, Email=request.Email,Message= request.Message,SubmittedAt=request.SubmittedAt};
                contactUs = await _contactUsRepository.AddAsync(contactUs);
                addContactUsCommandResponse = new Response<ContactUsDto>(_mapper.Map<ContactUsDto>(contactUs), "success");
            }

            return addContactUsCommandResponse;

        }
    }
}
