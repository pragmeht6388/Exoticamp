using AutoMapper;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, Response<IEnumerable<GetUserListDto>>>
    {
        
    
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetUserListQueryHandler(IMapper mapper,IUserService userService, ILogger<GetCategoriesListQueryHandler> logger)
        {
            _mapper = mapper;
            
            _logger = logger;
            _userService = userService;
        }

        public async Task<Response<IEnumerable<GetUserListDto>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allUser = (await  _userService.GetAllUserDetails()).OrderBy(x => x.Name).ToList();
            var user = _mapper.Map<IEnumerable<GetUserListDto>>(allUser);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetUserListDto>>(user, "success");
        }

    
}
}
