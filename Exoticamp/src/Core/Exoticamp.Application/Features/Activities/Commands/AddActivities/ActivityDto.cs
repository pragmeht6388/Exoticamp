using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Commands.AddActivities
{
    public class ActivityDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public ICollection<Domain.Entities.CampsiteDetails> CampsiteDetails { get; set; }
    }
}
