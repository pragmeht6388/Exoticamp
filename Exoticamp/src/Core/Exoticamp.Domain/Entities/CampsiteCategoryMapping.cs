using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class CampsiteCategoryMapping
    {
        public Guid Id { get; set; }
        public Guid CampsiteId { get; set; }
        public Campsite Campsite { get; set; }  

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
