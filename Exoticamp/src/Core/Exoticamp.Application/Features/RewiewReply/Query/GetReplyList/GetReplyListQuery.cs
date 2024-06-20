using Exoticamp.Application.Features.Reviews.Queryies.GetReviewList;
using Exoticamp.Application.Features.RewiewReply.Query.GetReplyById;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.RewiewReply.Query.GetReplyList
{
    public class GetReplyListQuery : IRequest<Response<IEnumerable<ReplyVm>>>
    {
    }
}
