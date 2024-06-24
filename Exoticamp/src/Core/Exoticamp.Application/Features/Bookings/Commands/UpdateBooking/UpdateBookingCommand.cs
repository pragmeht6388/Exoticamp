using Exoticamp.Application.Features.Events.Commands.UpdateEvent;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<Response<UpdateBookingDto>>
    {
        public Guid BookingId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50, MinimumLength = 3)]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Email is required."),]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        
        public DateTime CheckIn { get; set; }
        [Required(ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        
        public DateTime CheckOut { get; set; }
        [Required(ErrorMessage = "Enter the number of persons")]
        public int NoOfAdults { get; set; }
        [Required(ErrorMessage = "Enter the number of Childs")]
        public int NoOfChildrens { get; set; }
        [Required(ErrorMessage = "Enter the number of Tents")]
        public int NoOfTents { get; set; }

        public decimal TotalPrice { get; set; }

        public string? GlampingType { get; set; }
        //public decimal? PriceForAdults { get; set; }
        //public decimal? PriceForChildrens { get; set; }
        //public decimal? PriceForTents { get; set; }

        public string Status { get; set; }
        [Required(ErrorMessage = "Select Campsite")]
        public Guid CampsiteId { get; set; }
        [Required(ErrorMessage = "Select Location")]
        public Guid LocationId { get; set; }

        //public Guid? PaymentId { get; set; }

        
    }
}
