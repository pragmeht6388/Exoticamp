using Exoticamp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class Activities :AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<CampsiteDetails> CampsiteDetails { get; set; }=new List<CampsiteDetails>();
        public ICollection<Event> Events { get; set; }=new List<Event>();
    }
}
