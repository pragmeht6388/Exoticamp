using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Glamping.GetGlamping
{
    internal class GetGlampingDetailQueryHandler : IRequestHandler<GetGlampingDetailQuery, Response<GlampingDto>>
    {
        private readonly IAsyncRepository<Exoticamp.Domain.Entities.Glamping> _glampingRepository;
        private readonly IMapper _mapper;

        public GetGlampingDetailQueryHandler(IMapper mapper, IAsyncRepository<Exoticamp.Domain.Entities.Glamping> glampingRepository)
        {
            _mapper = mapper;
            _glampingRepository = glampingRepository;
        }

        public async Task<Response<GlampingDto>> Handle(GetGlampingDetailQuery request, CancellationToken cancellationToken)
        {
            var glamping = await _glampingRepository.GetByIdAsync(request.GlampingId);

            if (glamping == null)
            {
                throw new NotFoundException(nameof(Glamping), request.GlampingId);
            }

            var glampingDto = _mapper.Map<GlampingDto>(glamping);
            var response = new Response<GlampingDto>(glampingDto);
            response.Succeeded = true;

            return response;
        }
    }
}
