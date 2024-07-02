using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CartCampsite.Queries.GetCartById
{
    public class GetCampCartIdQuery : IRequest<Response<CampCartIdVM>>
    {
        public string Id { get; set; }
    }
}
