﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Commands.DeleteBooking
{
    public  class DeleteBookingCommand : IRequest<Unit>
    {
        public Guid BookingId { get; set; } 
    }
}
