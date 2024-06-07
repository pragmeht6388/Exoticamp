using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class CampsiteActivities
    {
        public Guid Id { get; set; }
        public Guid ActivitiesId { get; set; }

        [ForeignKey("ActivitiesId")]
        public Activities Activities { get; set; }
        public Guid CampsiteDetailsId {  get; set; }

        [ForeignKey("CampsiteDetailsId")]
        public CampsiteDetails CampsiteDetails { get; set; }


    }
}
