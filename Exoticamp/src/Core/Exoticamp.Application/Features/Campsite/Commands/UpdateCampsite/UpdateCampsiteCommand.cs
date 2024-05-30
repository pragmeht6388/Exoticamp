using Exoticamp.Application.Features.Products.Commands.UpdateProduct;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Campsite.Commands.UpdateCampsite
{
    public class UpdateCampsiteCommand: IRequest<Response<UpdateCampsiteDto>>
    {
        [Key]
        public Guid Id { get; set; }
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
