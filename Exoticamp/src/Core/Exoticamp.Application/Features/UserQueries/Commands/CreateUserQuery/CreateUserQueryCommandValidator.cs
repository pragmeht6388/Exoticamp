using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Helper;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.UserQueries.Commands.CreateUserQuery
{
    public class CreateUserQueryCommandValidator : AbstractValidator<CreateUserQueryCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public CreateUserQueryCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull();
            RuleFor(p => p.Query)
               .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
               .NotNull();
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
