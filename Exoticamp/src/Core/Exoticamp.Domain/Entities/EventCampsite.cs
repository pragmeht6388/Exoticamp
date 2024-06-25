using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
     public class EventCampsite
    {
        [Key]
        public  Guid Id { get; set; }
        public Guid EventId { get; set; }

        public Guid CampsiteId { get; set; }

        public  string ImageUrl { get; set; }

        public  virtual Event Event { get; set; }

        public virtual    CampsiteDetails Campsite   { get; set; }




    }
}
