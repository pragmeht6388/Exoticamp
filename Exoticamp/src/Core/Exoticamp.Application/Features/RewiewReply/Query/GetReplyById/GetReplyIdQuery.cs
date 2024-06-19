using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.RewiewReply.Query.GetReplyById
{
    public class GetReplyIdQuery : IRequest<Response<ReviewReplyVm>>
    {
        public string Id { get; set; }
    }
}
