using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Glamping.GetGlampingList
{
    internal class GetGlampingListDetailQueryHandler : IRequestHandler<GetGlampingListDetailQuery, Response<IEnumerable<GetGlampingListDto>>>
    {

        private readonly IAsyncRepository<Exoticamp.Domain.Entities.Glamping> _glampingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetGlampingListDetailQueryHandler> _logger;

        public GetGlampingListDetailQueryHandler(IMapper mapper, IAsyncRepository<Exoticamp.Domain.Entities.Glamping> glampingRepository, ILogger<GetGlampingListDetailQueryHandler> logger)
        {
            _mapper = mapper;
            _glampingRepository = glampingRepository;
            _logger = logger;
        }

        //public async Task<Response<IEnumerable<GetGlampingListDto>>> Handle(GetGlampingListDetailQuery request, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Handle Initiated");

        //    // Retrieve all glamping details from the repository
        //    var allGlampingDetails = await _glampingRepository.ListAllAsync();

        //    // Filter glamping details where IsDeleted is false
        //    //var notDeletedGlampingDetails = allGlampingDetails
        //    //    .Where(g => !g.IsDeleted);

        //    // Map the filtered glamping details to GetGlampingListDto
        //    var glampingDtos = _mapper.Map<IEnumerable<GetGlampingListDto>>(notDeletedGlampingDetails);

        //    _logger.LogInformation("Handle Completed");

        //    return new Response<IEnumerable<GetGlampingListDto>>(glampingDtos, "success");
        //}
        public async Task<Response<IEnumerable<GetGlampingListDto>>> Handle(GetGlampingListDetailQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            // Retrieve all glamping details from the repository
            var allGlampingDetails = await _glampingRepository.ListAllAsync();

            // Map all glamping details to GetGlampingListDto
            var glampingDtos = _mapper.Map<IEnumerable<GetGlampingListDto>>(allGlampingDetails);

            _logger.LogInformation("Handle Completed");

            return new Response<IEnumerable<GetGlampingListDto>>(glampingDtos, "success");
        }
    }

}
