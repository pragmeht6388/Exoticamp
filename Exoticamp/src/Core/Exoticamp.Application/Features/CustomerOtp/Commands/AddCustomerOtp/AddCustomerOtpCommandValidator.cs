using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerOtp.Commands.AddCustomerOtp
{
	internal class AddCustomerOtpCommandValidator : AbstractValidator<AddCustomerOtpCommand>
	{
		private readonly IMessageRepository _messageRepository;

		public AddCustomerOtpCommandValidator(IMessageRepository messageRepository)
		{
			_messageRepository = messageRepository;

			

		}
	}
	}
