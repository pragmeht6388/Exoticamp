using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using Exoticamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Persistence.Repositories
{
    public class CampsiteDetailsRepository:BaseRepository<CampsiteDetails>, ICampsiteDetailsRepository
    {
        private readonly ILogger _logger;
       // private readonly ApplicationDbContext _dbContext;
        public CampsiteDetailsRepository(ApplicationDbContext dbContext, ILogger<CampsiteDetails> logger) : base(dbContext, logger)
        {
            _logger = logger;
           // _dbContext = dbContext;
        }

        public Task<CampsiteDetails> AddCampsite(CampsiteDetails campsite)
        {
            throw new NotImplementedException();
        }

        public Task<CampsiteDetails> Delete(CampsiteDetails campsite)
        {
            throw new NotImplementedException();
        }

        public Task<List<CampsiteDetails>> GetAllCampsite(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }

        public Task<CampsiteDetails> Update(CampsiteDetails campsite)
        {
            throw new NotImplementedException();
        }
        public async Task<List<CampsiteDetailsVM>> GetAllCampsiteWithCategoryAndActivityDetails()
        {
            var data = await this._dbContext.CampsiteDetails.Select(request => new CampsiteDetailsVM()
            {

                Id = request.Id,
                Name = request.Name,
                // Location = request.Location,
                LocationId = request.LocationId,
                Status = request.Status,
                TentType = request.TentType,
                isActive = request.isActive,
                ApprovedBy = request.ApprovedBy,
                ApprovededDate = request.ApprovededDate,
                DeletededBy = request.DeletededBy,
                DeletedDate = request.DeletedDate,
                //CategoryName = request.Categories.Name,
                Images = request.Images,
                DateTime = request.DateTime,
                Highlights = request.Highlights,
                Ratings = request.Ratings,
                AboutCampsite = request.AboutCampsite,
                CampsiteRules = request.CampsiteRules,
                BestTimeToVisit = request.BestTimeToVisit,
                HowToGetHere = request.HowToGetHere,
                QuickSummary = request.QuickSummary,
                Itinerary = request.Itinerary,
                Inclusions = request.Inclusions,
                Exclusion = request.Exclusion,
                Amenities = request.Amenities,
                Accommodation = request.Accommodation,
                Safety = request.Safety,
                DistanceWithMap = request.DistanceWithMap,
                CancellationPolicy = request.CancellationPolicy,
               // CategoryId = request.CategoryId,
                //ActivitiesId = request.ActivitiesId,
                FAQs = request.FAQs,
                HouseRules = request.HouseRules,
                MealPlans = request.MealPlans,
                WhyExoticamp = request.WhyExoticamp,
               // ActivitiesName = request.Activities.Name

                //ActivitiesName=request.Activities.FirstOrDefault().Name

            }).ToListAsync();
            return data;
        }


    }
}
