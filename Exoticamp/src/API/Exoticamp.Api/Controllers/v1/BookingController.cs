
using Exoticamp.Application.Features.Bookings.Commands.AddBooking;
using Exoticamp.Application.Features.Bookings.Commands.DeleteBooking;
using Exoticamp.Application.Features.Bookings.Commands.UpdateBooking;
using Exoticamp.Application.Features.Bookings.Queries.GetBookingDetails;
using Exoticamp.Application.Features.Bookings.Queries.GetBookingList;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllBookings()
        {
            var dtos = await _mediator.Send(new GetBookingListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetBookingById")]
        public async Task<ActionResult> GetBookingById(string id)
        {
            var guidId = new Guid(id);
            var getEventDetailQuery = new GetBookingDeatilQuery() { BookingId = guidId };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddBooking")]
        public async Task<ActionResult> Create([FromBody] CreateBookingCommand createBookingCommand)
        {
            var dto = await _mediator.Send(createBookingCommand);

            return Ok(dto);


        }


        [HttpPut(Name = "UpdateBooking")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBookingCommand updateEventCommand)
        {
            var response = await _mediator.Send(updateEventCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteBookingCommand = new DeleteBookingCommand() { BookingId= id };
            await _mediator.Send(deleteBookingCommand);
            return NoContent();
        }
    }
}
