using AutoMapper;
using Exoticamp.Application.Contracts.Infrastructure;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Models.Mail;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.UserQueries.Commands.CreateUserQuery
{

    public class CreateUserQueryCommandHandler : IRequestHandler<CreateUserQueryCommand, Response<int>>
    {
        private readonly IAsyncRepository<UserQuery> _userQueryRepository;
        private readonly IMapper _mapper;
        //private readonly IEmailService _emailService;
        private readonly ILogger<CreateUserQueryCommandHandler> _logger;
        public CreateUserQueryCommandHandler(IAsyncRepository<UserQuery> userQueryRepository, IMapper mapper,
             ILogger<CreateUserQueryCommandHandler> logger)
        {
            _userQueryRepository = userQueryRepository;
            _mapper = mapper;
            //_emailService = emailService;
            _logger = logger;
        }
        public async Task<Response<int>> Handle(CreateUserQueryCommand request, CancellationToken cancellationToken)
        {
            var add = _mapper.Map<UserQuery>(request);
            var result = await _userQueryRepository.AddAsync(add);
            //var email = new Email()
            //{
            //    Body = "Your query has been sent to our team successfully! Someone from our support staff will answer it as soon as possible!",
            //    Subject = "Successfully sent the query!",
            //    To = add.Email,
            //};
            //try
            //{
            //    await _emailService.SendEmail(email);
            //}
            //catch (Exception ex)
            //{
            //    //this shouldn't stop the API from doing else so this can be logged
            //    _logger.LogError($"Mailing about event {add.Id} failed due to an error with the mail service: {ex.Message}");
            //}
            return new Response<int>(1, "Successfully added the query");
        }
    }
}
