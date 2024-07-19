using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public  class CustomerMPIN
    {
       
       
        [Key]
        public int PinId { get; set; }
        [MaxLength(6)]
        [MinLength(6)]
        public int MPIN {  get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
