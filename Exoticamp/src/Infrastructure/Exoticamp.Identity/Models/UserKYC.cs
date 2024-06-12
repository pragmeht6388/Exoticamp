using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Identity.Models
{
    public class UserKYC
    {
        public Guid Id { get; set; }
        public string IDCard { get; set; }
        public string License { get; set; }
        public string Address { get; set; }
        public string Others { get; set; }


        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }
        public string UserID { get; set; }

    }
}
