﻿using Exoticamp.UI.Models.ResponseModels.Reviews;
using Exoticamp.UI.Models.Reviews;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IReviewsRepository
    {
        Task<CreateReviewsResponseModel> AddReviews(ReviewsVM reviewsVM);

        Task<IEnumerable<ReviewsVM>> GetAllReviews();


    }
}
