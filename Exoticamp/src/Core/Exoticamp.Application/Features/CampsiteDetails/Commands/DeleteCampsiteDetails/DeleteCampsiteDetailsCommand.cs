using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CampsiteDetails.Commands.DeleteCampsiteDetails
{
    public class DeleteCampsiteDetailsCommand :IRequest
    {
        public string Id { get; set; }
        
    }


    }
