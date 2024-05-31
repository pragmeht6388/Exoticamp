using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.ContactUs.Command.AddContactUs;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Campsite.Commands.AddCampsite
{
    public class AddCampsiteHandler :  IRequestHandler<AddCampsiteCommand, Response<CampsiteDto>>
    {

        private readonly IMapper _mapper;
        private readonly ICampsiteRepository _campsiteRepository;
        private readonly IMessageRepository _messageRepository;

        public AddCampsiteHandler(IMapper mapper, ICampsiteRepository campsiteRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _campsiteRepository = campsiteRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CampsiteDto>> Handle(AddCampsiteCommand request, CancellationToken cancellationToken)
        {
            Response<CampsiteDto> addCampsiteCommandResponse = null;

            var validator = new AddCampsiteCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var campsite = new Domain.Entities.Campsite { Name = request.Name, Location = request.Location, Status = request.Status, TentType = request.TentType, isActive = true, ApprovedBy = request.ApprovedBy, ApprovededDate = request.ApprovededDate, DeletededBy = request.DeletededBy, DeletedDate = request.DeletedDate = request.DeletedDate = request.DeletedDate };
                campsite = await _campsiteRepository.AddAsync(campsite);
                addCampsiteCommandResponse = new Response<CampsiteDto>(_mapper.Map<CampsiteDto>(campsite), "success");
            }

            return addCampsiteCommandResponse;

        }
    }
}
