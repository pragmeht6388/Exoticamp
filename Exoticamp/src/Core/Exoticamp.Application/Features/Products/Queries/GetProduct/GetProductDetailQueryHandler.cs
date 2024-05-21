using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Categories.Queries.GetCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Products.Queries.GetProduct
{
    internal class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, Response<ProductVM>>
    {

        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetProductDetailQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository, IDataProtectionProvider provider)
        {
            _mapper = mapper;

            _productRepository = productRepository;

        }

        public async Task<Response<ProductVM>> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {


            var @product = await _productRepository.GetByIdAsync(new Guid(request.Id));
            var productDto = _mapper.Map<ProductVM>(@product);


            if (@product == null)
            {
                throw new NotFoundException(nameof(Product), @product.ProductId);
            }

            var response = new Response<ProductVM>(productDto);
            return response;
        }
    }
}
