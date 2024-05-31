using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Campsite.Commands.DeleteCampsite
{
    public class DeleteCampsiteCommand : IRequest<Unit>
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        public string TentType { get; set; }
        public bool? isActive { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovededDate { get; set; }
        public string? DeletededBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
