using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Commands.UpdateActivities
{
    internal class UpdateActivitiesHandler : IRequestHandler<UpdateActivitiesCommand, Response<UpdateActivitiesDto>>
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public UpdateActivitiesHandler(IMapper mapper, IActivitiesRepository activitiesRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _activitiesRepository = activitiesRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<UpdateActivitiesDto>> Handle(UpdateActivitiesCommand request, CancellationToken cancellationToken)
        {
            var activitiesToUpdate = await _activitiesRepository.GetByIdAsync(request.Id);

            if (activitiesToUpdate == null)
            {
                throw new NotFoundException(nameof(Campsite), request.Id);
            }

            // Check if the campsite is active
            //if (campsiteToUpdate.isActive == false)
            //{
            //    throw new InvalidOperationException("Cannot update an inactive campsite.");
            //}

            var validator = new updateActivitiesCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, activitiesToUpdate);

            await _activitiesRepository.UpdateAsync(activitiesToUpdate);

            var dto = new UpdateActivitiesDto
            {
                Id = request.Id,
                Name = request.Name,
                

            };

            return new Response<UpdateActivitiesDto>(dto, "Updated successfully");
        }



    }

}
