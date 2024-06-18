using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Reviews.Queryies.GetReviewById
{
    public class GetReviewIdQuery : IRequest<Response<ReviewsVM>>
    {
        public string Id { get; set; }
    }
}
