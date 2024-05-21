using AutoMapper;
using FluentValidation;
using MediatR;
using MyCleanProject1.Application.Contracts.Persistence;
using MyCleanProject1.Application.Features.Products.Commands.AddProduct;
using MyCleanProject1.Application.Response;
using MyCleanProject1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Features.Products.Commands.AddProduct
{
    internal class AddProductHandler : IRequestHandler<AddProductCommand, Response<ProductDto>>
    {

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IMessageRepository _messageRepository;

        public AddProductHandler(IMapper mapper, IProductRepository productRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<ProductDto>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            Response<ProductDto> addProductCommandResponse = null;

            var validator = new AddProductCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException((IEnumerable<FluentValidation.Results.ValidationFailure>)validationResult);
            }
            else
            {
                var product = new Product { Name = request.Name,Price=request.Price };
                product = await _productRepository.AddAsync(product);
                addProductCommandResponse = new Response<ProductDto>(_mapper.Map<ProductDto>(product), "success");
            }

            return addProductCommandResponse;

        }
    }
}
