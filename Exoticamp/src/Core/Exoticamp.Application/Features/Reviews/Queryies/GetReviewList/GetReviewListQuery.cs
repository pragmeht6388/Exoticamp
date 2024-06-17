using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Reviews.Queryies.GetReviewList
{
    public class GetReviewListQuery : IRequest<Response<IEnumerable<ReviewVM>>>
    {
        public string BookingId {  get; set; }
    }
}
