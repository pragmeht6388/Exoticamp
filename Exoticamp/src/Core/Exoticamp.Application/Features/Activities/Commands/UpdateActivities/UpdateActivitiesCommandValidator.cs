using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Commands.UpdateActivities
{
    public class updateActivitiesCommandValidator : AbstractValidator<UpdateActivitiesCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public updateActivitiesCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        }
    }

}
