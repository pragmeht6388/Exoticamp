﻿using AutoMapper;
using Exoticamp.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;

namespace Exoticamp.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, Response<EventDetailVm>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetEventDetailQueryHandler(IMapper mapper, IEventRepository eventRepository, IAsyncRepository<Category> categoryRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Response<EventDetailVm>> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            // string id = _protector.Unprotect(request.Id);

            var eventDetailDto= await _eventRepository.GetEventById(request.Id);

            //var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

            //if (category == null)
            //{
            //    throw new NotFoundException(nameof(Category), @event.CategoryId);
            //}
            // eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

            var response = new Response<EventDetailVm>(eventDetailDto);
            return response;
        }
    }
}
