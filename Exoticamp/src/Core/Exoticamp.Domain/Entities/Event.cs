using Exoticamp.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.Domain.Entities
{
    public class Event : AuditableEntity
    {
        [Key]
        public Guid EventId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Highlights { get; set; }
        [Required]
        public string EventRules { get; set; }
        //public Guid CampsiteId { get; set; }
        //public Campsite Campsite { get; set; }
        //public Guid ActivityId { get; set; }
        //public Activity activity { get; set; }
        //public Guid LocationId { get; set; }
        //public Location location { get; set; }

    }
}
