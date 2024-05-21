using FluentValidation;
using MyCleanProject1.Application.Contracts.Persistence;
using MyCleanProject1.Application.Features.Categories.Commands.CreateCategory;
using MyCleanProject1.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Features.Products.Commands.AddProduct
{
    internal class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public AddProductCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(10).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));
            RuleFor(p => p.Price)
              .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
              .GreaterThan(0);
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
