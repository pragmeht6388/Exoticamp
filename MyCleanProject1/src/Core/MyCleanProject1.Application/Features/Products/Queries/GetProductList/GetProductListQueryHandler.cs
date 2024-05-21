using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyCleanProject1.Application.Contracts.Persistence;
using MyCleanProject1.Application.Features.Categories.Queries.GetCategoriesList;
using MyCleanProject1.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Features.Products.Queries.GetProductList
{
    internal class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, Response<IEnumerable<ProductVM>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetProductListQueryHandler(IMapper mapper, IProductRepository productRepository, ILogger<GetCategoriesListQueryHandler> logger)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ProductVM>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var allProducts = (await _productRepository.ListAllAsync()).OrderBy(x => x.Name);
            var product = _mapper.Map<IEnumerable<ProductVM>>(allProducts);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<ProductVM>>(product, "success");
        }
    }
}
