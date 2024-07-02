using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class CartCamp
    {
        [Key]
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public DateOnly CheckIn { get; set; }
        public DateOnly CheckOut { get; set; }
        public int? NoOfAdults { get; set; }
        public int? NoOfChildrens { get; set; }
        public int? NoOfTents { get; set; }
        public decimal TotalPrice { get; set; }
     
        public string? Status { get; set; }
        public Guid CampsiteId { get; set; }
        public Guid? LocationId { get; set; }
       
        public Guid GlampingId { get; set; }
        public int? NoOfGlamps { get; set; }
        public bool? IsActive { get; set; }
        public Guid? GuestDetailsId { get; set; }
        public GuestDetails? GuestDetails { get; set; }
        public virtual CampsiteDetails Campsite { get; set; }
        public virtual Location Location { get; set; }



    }
}
