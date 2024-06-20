using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Contracts;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using Exoticamp.Application.Features.Reviews.Queryies.GetReviewList;
using Exoticamp.Application.Features.RewiewReply.Query.GetReplyById;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.RewiewReply.Query.GetReplyList
{
    internal class GetReplyListQueryHandler : IRequestHandler<GetReplyListQuery, Response<IEnumerable<ReplyVm>>>
    {
        private readonly IReviewReplyRepository _replyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ICampsiteDetailsRepository _campsiteDetailsRepository;

        public GetReplyListQueryHandler(IMapper mapper, IReviewReplyRepository replyRepository, ILogger<GetReplyListQuery> logger, ILoggedInUserService loggedInUserService, ICampsiteDetailsRepository campsiteDetailsRepository)
        {
            _mapper = mapper;
            _replyRepository = replyRepository;
            _logger = logger;
            _loggedInUserService = loggedInUserService;
            _campsiteDetailsRepository = campsiteDetailsRepository;
        }

        public async Task<Response<IEnumerable<ReplyVm>>> Handle(GetReplyListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            var allReviews = await _replyRepository.ListAllAsync();

            

            

            var orderedReview = allReviews.OrderBy(x => x.Reply);

            var reviewVMs = _mapper.Map<IEnumerable<ReplyVm>>(orderedReview);

            _logger.LogInformation("Hanlde Completed");

            return new Response<IEnumerable<ReplyVm>>(reviewVMs, "success");
        }
    }
}
