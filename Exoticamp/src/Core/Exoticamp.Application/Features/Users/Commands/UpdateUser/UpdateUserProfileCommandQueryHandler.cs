using AutoMapper;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Users.Queries.GetUser;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserProfileCommandQueryHandler : IRequestHandler<UpdateUserProfileCommand, Response<string>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
      
        public UpdateUserProfileCommandQueryHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
           
        }

        public async Task<Response<string>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<GetUserDto>(request);
            var result = await _userService.UpdateUser(model);
            return new Response<string>(result, "Success");
        }
    }
}
