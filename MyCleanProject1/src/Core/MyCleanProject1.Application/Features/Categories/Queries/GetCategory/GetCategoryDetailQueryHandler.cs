using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using MyCleanProject1.Application.Contracts.Persistence;
using MyCleanProject1.Application.Exceptions;
using MyCleanProject1.Application.Features.Events.Queries.GetEventDetail;
using MyCleanProject1.Application.Response;
using MyCleanProject1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, Response<CategoryVM>>
    {
        
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetCategoryDetailQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;
     
            _categoryRepository = categoryRepository;
          
        }

        public async Task<Response<CategoryVM>> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            

            var @category = await _categoryRepository.GetByIdAsync(new Guid(request.Id));
            var categoryDetailDto = _mapper.Map<CategoryVM>(@category);


            if (@category == null)
            {
                throw new NotFoundException(nameof(Category), @category.CategoryId);
            }

            var response = new Response<CategoryVM>(categoryDetailDto);
            return response;
        }
    }
}
