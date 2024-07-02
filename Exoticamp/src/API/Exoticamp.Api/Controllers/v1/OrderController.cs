 
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Exoticamp.Application.Features.Orders.Queries.GetOrdersForMonth;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class OrderController(IMediator _mediator) : ControllerBase
    {
       


        [HttpGet(Name = "GetOrdersForMonth")]
        public async Task<ActionResult> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };
            var dtos = await _mediator.Send(getOrdersForMonthQuery);
            return Ok(dtos);
        }
    }
}
