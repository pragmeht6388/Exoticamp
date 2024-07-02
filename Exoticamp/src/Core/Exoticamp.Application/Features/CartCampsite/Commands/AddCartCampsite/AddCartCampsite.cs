using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CartCampsite.Commands.AddCartCampsite
{
    
    public class AddCartCampsite : IRequest<Response<CartCampDto>>
    {
        public Guid UserId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
        public int? NoOfAdults { get; set; }
        public int? NoOfChildren { get; set; }
        public int? NoOfTents { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
        public Guid CampsiteId { get; set; }
        public decimal? PriceForAdults { get; set; }
        // public Guid? LocationId { get; set; }
        //public Guid GlampingId { get; set; }
        public int? NoOfGlamps { get; set; }
        public bool? IsActive { get; set; }
        //public Guid? GuestDetailsId { get; set; }
    }
}
