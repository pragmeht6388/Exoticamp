using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryList
{
    public class GetUserQueryListVM
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Query { get; set; }
    }
}
