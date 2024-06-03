using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exoticamp.UI.Models.Events
{
    public class EventVM
    {
       public string? EventId { get; set; }
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
        [NotMapped]
        public IFormFile Image { get; set; }
       
        public string? ImageUrl { get; set; }
        [Required]
        public string Highlights { get; set; }
        [Required]
        public string EventRules { get; set; }
        //public Guid CampsiteId { get; set; }
        //public Category Campsite { get; set; }
        //public Guid ActivityId { get; set; }
        //public Activity activity { get; set; }
        // public Guid LocationId { get; set; }
        //public Location location { get; set; }
    }
}
