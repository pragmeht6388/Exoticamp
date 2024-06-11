using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Identity.Models
{
    public  class BankDetails
    {

        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }

        [ForeignKey("UserID")]
        public  ApplicationUser  User { get; set; }
        public string UserID { get; set; }
    }
}
