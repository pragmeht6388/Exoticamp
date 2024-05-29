using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Models.Authentication
{
    public class CreateRoleRequest
    {
        public string CreateBy { get; set; }
        public string RoleName { get; set; }
    }
}
