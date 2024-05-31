using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.UserQueries.Commands.CreateUserQuery;
using Exoticamp.Application.Models.Mail;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.UserQueries.Commands.RespondToUserQuery
{
    public class RespondToUserQueryCommandHandler : IRequestHandler<RespondToUserQueryCommand, Response<Guid>>
    {
        private readonly IAsyncRepository<UserQuery> _userQueryRepository;
        private readonly IMapper _mapper;
        public RespondToUserQueryCommandHandler(IAsyncRepository<UserQuery> userQueryRepository, IMapper mapper)
        {
            _userQueryRepository = userQueryRepository;
            _mapper = mapper;
        }
        public async Task<Response<Guid>> Handle(RespondToUserQueryCommand request, CancellationToken cancellationToken)
        {
            var userQuery = await _userQueryRepository.GetByIdAsync(request.Id);
            userQuery.Response = request.Response;
            userQuery.IsDeleted = true;
            var result = _userQueryRepository.UpdateAsync(userQuery);

            //var email = new Email()
            //{
            //    Body = "Your query has been sent to our team successfully! Someone from our support staff will answer it as soon as possible!",
            //    Subject = "Successfully sent the query!",
            //    To = add.Email,
            //};
            return new Response<Guid>(userQuery.Id, "Successfully added the query");
        }
    }
}
