using Exoticamp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class Campsite:AuditableEntity
    {
        [Key]
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Location { get; set; } 
        public bool Status { get; set; }
        public string TentType { get; set; } 
        public bool? isActive {  get; set; } //whether it is deleted or not
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovededDate { get; set; }
        public string? DeletededBy { get; set; }
        public DateTime? DeletedDate { get; set; }

    }

}

