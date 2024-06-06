using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class CampsiteCategories
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public Guid CampsiteDetailsId { get; set; }

        [ForeignKey("CampsiteDetailsId")]
        public CampsiteDetails CampsiteDetails { get; set; }
    }
}
