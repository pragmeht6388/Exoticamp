using Azure.Core;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails;
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
    public class CampsiteDetailsRepository : BaseRepository<CampsiteDetails>, ICampsiteDetailsRepository
    {
        private readonly ILogger _logger;
        // private readonly ApplicationDbContext _dbContext;
        public CampsiteDetailsRepository(ApplicationDbContext dbContext, ILogger<CampsiteDetails> logger) : base(dbContext, logger)
        {
            _logger = logger;
            // _dbContext = dbContext;
        }

        public async Task<CampsiteDetails> AddCampsite(AddCampsiteDetailsCommand request)
        {
            var campsite = new CampsiteDetails();
            _dbContext.BeginTransaction();
            try
            {

                var activity = await _dbContext.Activities.FirstOrDefaultAsync(x => x.Id == request.ActivitiesId);


                if (activity == null)
                    throw new NotFoundException("Activity not found", activity);


                campsite = new Domain.Entities.CampsiteDetails
                {
                    Name = request.Name,
                    Location = request.Location,
                    Status = request.Status,
                    TentType = request.TentType,
                    isActive = true,
                    ApprovedBy = request.ApprovedBy,
                    ApprovededDate = request.ApprovededDate,
                    DeletededBy = request.DeletededBy,
                    DeletedDate = request.DeletedDate,
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
                    FAQs = request.FAQs,
                    HouseRules = request.HouseRules,
                    MealPlans = request.MealPlans,
                    WhyExoticamp = request.WhyExoticamp
                };
                await _dbContext.Set<CampsiteDetails>().AddAsync(campsite);
                //await _dbContext.SaveChangesAsync();

                if (activity == null)
                { throw new NotFoundException("Activity not found", campsite); }


                var campsiteActivities = new CampsiteActivities()
                {
                    Id = Guid.NewGuid(),
                    ActivityId = request.ActivitiesId,
                    CampsiteId = campsite.Id,

                };
                await _dbContext.Set<CampsiteActivities>().AddAsync(campsiteActivities);
               
                await _dbContext.SaveChangesAsync();
                _dbContext.Commit();

            }
            catch (Exception ex)
            {

                _dbContext.Rollback();
            }
            return campsite;
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
            var data = await this._dbContext.CampsiteDetails.Include(x => x.CampsiteActivities).Select(request => new CampsiteDetailsVM()
            {

                Id = request.Id,
                Name = request.Name,
                Location = request.Location,
                Status = request.Status,
                TentType = request.TentType,
                isActive = request.isActive,
                ApprovedBy = request.ApprovedBy,
                ApprovededDate = request.ApprovededDate,
                DeletededBy = request.DeletededBy,
                DeletedDate = request.DeletedDate,
                // ActivitiesName = request.CampsiteActivities.FirstOrDefault().,
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
                //CategoryId = request.CategoryId,
                //CampsiteActivities = request.CampsiteActivities,
                FAQs = request.FAQs,
                HouseRules = request.HouseRules,
                MealPlans = request.MealPlans,
                WhyExoticamp = request.WhyExoticamp,
                //ActivitiesName = request.Activities.Name
                //ActivitiesName=request.Activities.FirstOrDefault().Name

            }).ToListAsync();
            return data;
        }


    }
}
