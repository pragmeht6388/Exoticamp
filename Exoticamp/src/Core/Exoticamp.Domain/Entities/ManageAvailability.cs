using Exoticamp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public  class ManageAvailability:AuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfPerson {  get; set; }
        public string Reason {  get; set; }
        public Guid? GlapmingId { get; set; }
        public virtual Glamping Glamping { get; set; }

    }
}
