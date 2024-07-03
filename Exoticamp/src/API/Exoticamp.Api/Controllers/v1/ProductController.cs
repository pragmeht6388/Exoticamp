using MediatR;
using Microsoft.AspNetCore.Mvc;
using Exoticamp.Application.Features.Products.Commands.AddProduct;
using Exoticamp.Application.Features.Products.Commands.UpdateProduct;
using Exoticamp.Application.Features.Products.Queries.GetProduct;
using Exoticamp.Application.Features.Products.Queries.GetProductList;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductController(IMediator _mediator, ILogger<ProductController> _logger) : ControllerBase
    {
      

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult> Create([FromBody] AddProductCommand addProductCommand)
        {
            var response = await _mediator.Send(addProductCommand);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(string id)
        {
            var getProductDetailQuery = new GetProductDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getProductDetailQuery));
        }

        [HttpGet("all", Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllProducts()
        {
            _logger.LogInformation("GetAllProducts Initiated");
            var dtos = await _mediator.Send(new GetProductListQuery());
            _logger.LogInformation("GetAllProducts Completed");
            return Ok(dtos);
        }

        [HttpPut("UpdateProduct", Name = "UpdateProduct")]
       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            var response = await _mediator.Send(updateProductCommand);
            return Ok(response);
        }

    }
}
