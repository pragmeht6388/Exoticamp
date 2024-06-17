using Exoticamp.UI.Models.ResponseModels.ReviewReply;
using Exoticamp.UI.Models.ResponseModels.Reviews;
using Exoticamp.UI.Models.ReviewReply;
using Exoticamp.UI.Models.Reviews;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IReviewReplyRepository
    {
        Task<CreateReviewReplyResponseModel> AddReviewsReply(ReviewReplyVM reviewsVM);
    }
}
