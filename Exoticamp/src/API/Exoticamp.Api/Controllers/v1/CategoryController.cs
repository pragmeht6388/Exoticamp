using MediatR;
using Microsoft.AspNetCore.Mvc;
using Exoticamp.Application.Features.Categories.Commands.UpdateCategory;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Exoticamp.Application.Features.Categories.Commands.StoredProcedure;
using Exoticamp.Application.Features.Categories.Commands.CreateCategory;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Features.Categories.Queries.GetCategory;

namespace Exoticamp.Api.Controllers.v1
{

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CategoryController(IMediator _mediator, ILogger<CategoryController> _logger) : ControllerBase
    {
        

    
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllCategories()
        {
            _logger.LogInformation("GetAllCategories Initiated");
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            _logger.LogInformation("GetAllCategories Completed");
            return Ok(dtos);
        }


        [HttpGet("allwithevents", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCategoriesWithEvents(bool includeHistory)
        {
            GetCategoriesListWithEventsQuery getCategoriesListWithEventsQuery = new GetCategoriesListWithEventsQuery() { IncludeHistory = includeHistory };

            var dtos = await _mediator.Send(getCategoriesListWithEventsQuery);
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult> GetCategoryById(string id)
        {
            var getCategoryDetailQuery = new GetCategoryDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getCategoryDetailQuery));
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }


        [HttpPut("UpdateCategory", Name = "UpdateCategory")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            var response = await _mediator.Send(updateCategoryCommand);
            return Ok(response);
        }




        [HttpPost("StoredProcedureDemo", Name = "StoredProcedureDemo")]
        public async Task<ActionResult> StoredProcedureDemo([FromBody] StoredProcedureCommand storedProcedureCommand)
        {
            var response = await _mediator.Send(storedProcedureCommand);
            return Ok(response);
        }
    }
}
