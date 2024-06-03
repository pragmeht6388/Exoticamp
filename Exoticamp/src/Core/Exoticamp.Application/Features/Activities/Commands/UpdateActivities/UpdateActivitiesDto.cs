using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Commands.UpdateActivities
{
    public class UpdateActivitiesDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public ICollection<Domain.Entities.CampsiteDetails> CampsiteDetails { get; set; } = new List<Domain.Entities.CampsiteDetails>();
    }
}
