using AutoMapper;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Features.Users.Queries.GetUserList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Vendors.Queries.GetVendorList
{
    public class GetVendorListHandler: IRequestHandler< GetVendorListQuery, Response<IEnumerable< GetVendorListDto>>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetVendorListHandler(IMapper mapper, IUserService userService, ILogger<GetCategoriesListQueryHandler> logger)
        {
            _mapper = mapper;

            _logger = logger;
            _userService = userService;
        }
        public async Task<Response<IEnumerable<GetVendorListDto>>> Handle(GetVendorListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allUser = (await _userService.GetAllVendorDetails()).OrderBy(x => x.Name).ToList();
            var user = _mapper.Map<IEnumerable< GetVendorListDto>>(allUser);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetVendorListDto>>(user, "success");
        }

    }
}
