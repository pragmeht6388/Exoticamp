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

namespace Exoticamp.Application.Features.Activities.Commands.AddActivities
{
    public class AddActivitiesHandler : IRequestHandler<AddActivitiesCommands, Response<ActivityDto>>
    {

        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activityRepository;
        private readonly IMessageRepository _messageRepository;

        public AddActivitiesHandler(IMapper mapper, IActivitiesRepository activityRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<ActivityDto>> Handle(AddActivitiesCommands request, CancellationToken cancellationToken)
        {
            Response<ActivityDto> addActivityCommandResponse = null;

            var validator = new AddActivityCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var activities = new Domain.Entities.Activities { Name = request.Name};
                activities = await _activityRepository.AddAsync(activities);
                addActivityCommandResponse = new Response<ActivityDto>(_mapper.Map<ActivityDto>(activities), "success");
            }

            return addActivityCommandResponse;

        }
    }

}
