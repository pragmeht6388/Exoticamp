//using AutoMapper;
//using Exoticamp.Application.Contracts.Persistence;
//using Exoticamp.Application.Features.Events.Queries.GetEventsList;
//using Exoticamp.Application.Responses;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Exoticamp.Application.Features.TentAvailability
//{
//    public class GetAllTentsListQueryHandler : IRequestHandler<GetAllTentsListQuery, Response<IEnumerable<TentAvailabilityVM>>>
//    {
//        private readonly  ITentAvailabilityRepository _tentAvailabilityRepository;
//        private readonly IMapper _mapper;

//        public GetAllTentsListQueryHandler(IMapper mapper, ITentAvailabilityRepository tentAvailabilityRepository)
//        {
//            _mapper = mapper;
//            _tentAvailabilityRepository= tentAvailabilityRepository;
//        }

//        public async Task<Response<IEnumerable<TentAvailabilityVM>>> Handle(GetAllTentsListQuery request, CancellationToken cancellationToken)
//        {
//            var alltents = await _tentAvailabilityRepository.ListAllAsync();
//            var tentList = _mapper.Map<List<TentAvailabilityVM>>(alltents);
//            var response = new Response<IEnumerable<TentAvailabilityVM>>(tentList);
//            return response;
//        }

      
//    }
//}
