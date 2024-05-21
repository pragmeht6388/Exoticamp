using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using MyCleanProject1.Application.Contracts.Persistence;
using MyCleanProject1.Application.Exceptions;
using MyCleanProject1.Application.Features.Categories.Queries.GetCategory;
using MyCleanProject1.Application.Response;
using MyCleanProject1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Features.Products.Queries.GetProduct
{
    internal class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, Response<ProductVM>>
    {

        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetProductDetailQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository,  IDataProtectionProvider provider)
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
