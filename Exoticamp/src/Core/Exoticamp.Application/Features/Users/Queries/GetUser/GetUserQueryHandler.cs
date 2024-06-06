using AutoMapper;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<GetUserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserQueryHandler> _logger;
        private readonly IAsyncRepository<Location> _location;
        private readonly IAsyncRepository<Exoticamp.Domain.Entities.Activities> _activity;
        public GetUserQueryHandler(IMapper mapper, IUserService userService, ILogger<GetUserQueryHandler> logger,
            IAsyncRepository<Location> location, IAsyncRepository<Exoticamp.Domain.Entities.Activities> activity 
            )
        {
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
            _location = location;
            _activity = activity;
        }
        public async Task<Response<GetUserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserDetailsById(request.UserId);
            var location = await _location.GetByIdAsync(user.LocationId);
            var activity = await _activity.GetByIdAsync(user.PreferenceId);
            user.Location = location.Name;
            user.Preference = activity.Name;
            return new Response<GetUserDto>(user, "success");
        }
    }
}
