using Exoticamp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.Domain.Entities
{
    public class Category : AuditableEntity
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        //public ICollection<Event> Events { get; set; }
        public ICollection<CampsiteDetails> CampsiteDetails { get; set; }


    }
}
