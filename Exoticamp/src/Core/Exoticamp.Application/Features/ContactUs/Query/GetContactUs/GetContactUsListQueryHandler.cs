using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Features.Products.Queries.GetProductList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.ContactUs.Query.GetContactUs
{
    internal class GetContactUsListQueryHandler : IRequestHandler<GetContactUsListQuery, Response<IEnumerable<ContactUsVM>>>
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetContactUsListQueryHandler(IMapper mapper, IContactUsRepository contactUsRepository, ILogger<GetContactUsListQueryHandler> logger)
        {
            _mapper = mapper;
            _contactUsRepository = contactUsRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ContactUsVM>>> Handle(GetContactUsListQuery request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var allContactUs = (await _contactUsRepository.ListAllAsync()).OrderBy(x => x.Name);
            var contactUs = _mapper.Map<IEnumerable<ContactUsVM>>(allContactUs);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<ContactUsVM>>(contactUs, "success");
        }
    }
}
