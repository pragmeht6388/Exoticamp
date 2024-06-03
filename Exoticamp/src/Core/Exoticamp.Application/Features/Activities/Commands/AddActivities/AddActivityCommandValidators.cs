using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Commands.AddActivities
{
    internal class AddActivityCommandValidator : AbstractValidator<AddActivitiesCommands>
    {
        private readonly IMessageRepository _messageRepository;

        public AddActivityCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            //RuleFor(p => p.Location)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters."); ;

            //RuleFor(p => p.Message)
            //   .NotEmpty().WithMessage("{PropertyName} is required.")
            //   .NotNull()
            //   .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
        }

    }
}
