using Exoticamp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class ReviewReply:AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Reply {  get; set; }
        public Guid ReviewId { get; set; }
        public virtual Reviews Reviews { get; set; }
    }
}
