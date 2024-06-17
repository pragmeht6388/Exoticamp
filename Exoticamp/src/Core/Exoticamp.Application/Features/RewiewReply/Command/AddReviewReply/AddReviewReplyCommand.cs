using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using Exoticamp.Application.Features.Reviews.Commands.AddReviews;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.RewiewReply.Command.AddReviewReply
{
    public class AddReviewReplyCommand : IRequest<Response<ReviewReplyDto>>
    {
        public string Reply { get; set; }
        public Guid ReviewId { get; set; }

        public Guid ReviewsId { get; set; }

        //public virtual Domain.Entities.Reviews Reviews { get; set; }
    }
}
