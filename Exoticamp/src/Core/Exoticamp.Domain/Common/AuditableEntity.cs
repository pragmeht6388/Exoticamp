using System;

namespace Exoticamp.Domain.Common
{
    public class AuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
