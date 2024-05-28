using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class UserQuery
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Query { get; set; }
        public string? Response { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
