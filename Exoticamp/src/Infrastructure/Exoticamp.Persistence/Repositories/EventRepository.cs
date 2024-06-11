using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;

using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;

using Exoticamp.Application.Features.Events.Commands.CreateEvent;

using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Events.Queries.GetEventDetail;
using Exoticamp.Application.Features.Events.Queries.GetEventsList;
using Exoticamp.Application.Features.Events.Commands.UpdateEvent;


namespace Exoticamp.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly ILogger _logger;
        public EventRepository(ApplicationDbContext dbContext, ILogger<Event> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            _logger.LogInformation("GetCategoriesWithEvents Initiated");
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.StartDate.Date.Equals(eventDate.Date));
            _logger.LogInformation("GetCategoriesWithEvents Completed");
            return Task.FromResult(matches);
        }

        public async Task<Event> AddEventWithCategory(Event @event)
        {
            //try { } catch (Exception ex) {

            //    _dbContext.Rollback();
            //} 
            _dbContext.BeginTransaction();
            //  var categories = await _dbContext.Set<Category>().ToListAsync();
            //  var category = categories.FirstOrDefault(x => x.Name == @event.Category.Name);
            //if (category != null)
            //{
            //    @event.Category = category;
            //    @event.CategoryId = category.CategoryId;
            //}
            //else
            //{
            //    await _dbContext.Set<Category>().AddAsync(@event.Category);
            //    await _dbContext.SaveChangesAsync();
            //    @event.CategoryId = @event.Category.CategoryId;
            //}
            //await _dbContext.Set<Event>().AddAsync(@event);
            //await _dbContext.SaveChangesAsync();
            //_dbContext.Commit();
            //return @event;

            await _dbContext.Set<Event>().AddAsync(@event);
            await _dbContext.SaveChangesAsync();
            _dbContext.Commit();
            return @event;
        }

        public async Task<Event> AddEvent(CreateEventCommand request)
        {
            _dbContext.BeginTransaction();
            var @event = new Event();
            try
            {

                var campsite = await _dbContext.CampsiteDetails.FirstOrDefaultAsync(x => x.Id == request.CampsiteId);
                var activity = await _dbContext.Activities.FirstOrDefaultAsync(x => x.Id == request.ActivityId);

                var location = await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == request.locationId);

                if (campsite == null)
                    throw new NotFoundException("Campsite not found", @event);


                @event.Name = request.Name;
                @event.Price = request.Price;
                @event.Capacity = request.Capacity;
                @event.StartDate = request.StartDate;
                @event.EndDate = request.EndDate;
                @event.Description = request.Description;
                @event.ImageUrl = request.ImageUrl;
                @event.Highlights = request.Highlights;
                @event.EventRules = request.EventRules;
                @event.Status = request.Status;
                @event.IsDeleted = request.IsDeleted;
                @event.Campsite = campsite;
                @event.CampsiteId = request.CampsiteId;
                await _dbContext.Set<Event>().AddAsync(@event);
                //await _dbContext.SaveChangesAsync();

                if (activity == null)
                { throw new NotFoundException("Activity not found", @event); }


                var eventActivities = new EventActivities()
                {
                    ActivityId = request.ActivityId,

                    EventId = @event.EventId,
                    Event = @event,
                    Activity = activity
                };
                await _dbContext.Set<EventActivities>().AddAsync(eventActivities);
                //await _dbContext.SaveChangesAsync();

                if (location == null)
                {
                    throw new NotFoundException("Location not found", @event);
                }
                var eventLocation = new EventLocation()
                {
                    LocationId = request.locationId,
                    EventId = @event.EventId,
                    Location = location,
                    Event = @event

                };
                await _dbContext.Set<EventLocation>().AddAsync(eventLocation);
                //await _dbContext.SaveChangesAsync();


                await _dbContext.SaveChangesAsync();
                _dbContext.Commit();



                //return @event;


            }
            catch (Exception ex)
            {

                _dbContext.Rollback();
            }
            return @event;
        }

        public async Task<EventDetailVm> GetEventById(Guid id)
        {
            _dbContext.BeginTransaction();
            var data = await _dbContext.Events.Include(x => x.EventLocations).Include(x => x.EventActivities).Where(x => x.EventId == id).Select(x => new EventDetailVm
            {
                ActivityId = x.EventActivities.FirstOrDefault()!.ActivityId,
                LocationId = x.EventLocations.FirstOrDefault()!.LocationId,
                EventId = x.EventId,
                Name = x.Name,
                Price = x.Price,
                Capacity = x.Capacity,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Highlights = x.Highlights,
                EventRules = x.EventRules,
                Status = x.Status,
                IsDeleted = x.IsDeleted,
                CampsiteId = x.CampsiteId,
                EventLocationDto = new EventLocationDto
                {
                    Id = x.EventLocations.FirstOrDefault()!.Id,
                    LocationId = x.EventLocations.FirstOrDefault()!.LocationId,
                    LocationDetails = new LocationDetails { Name = x.EventLocations.FirstOrDefault(y => y.Id == x.EventLocations.FirstOrDefault()!.Id)!.Location.Name }

                },
                EventActivityDto = new EventActivityDto
                {
                    Id = x.EventActivities.FirstOrDefault()!.Id,
                    ActivityId = x.EventActivities.FirstOrDefault()!.ActivityId,
                    ActivityDetails = new ActivityDetails {  Name = x.EventActivities.FirstOrDefault(y=>y.Id==x.EventActivities.FirstOrDefault()!.Id)!.Activity.Name}
                }



            }).FirstOrDefaultAsync();
            _dbContext.Commit();

            return data;
        }

        public async Task<List<EventListVm>> GetAllEvents()
        {
            _dbContext.BeginTransaction();
            var data = await _dbContext.Events.Include(x => x.EventLocations).Include(x => x.EventActivities).Select(x => new EventListVm
            {
                ActivityId = x.EventActivities.FirstOrDefault()!.ActivityId,
                LocationId = x.EventLocations.FirstOrDefault()!.LocationId,
                EventId = x.EventId,
                Name = x.Name,
                Price = x.Price,
                Capacity = x.Capacity,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Highlights = x.Highlights,
                EventRules = x.EventRules,
                Status = x.Status,
                IsDeleted = x.IsDeleted,
                CampsiteId = x.CampsiteId,
                EventLocationDto = new EventLocationDto
                {
                    Id = x.EventLocations.FirstOrDefault()!.Id,
                    LocationId = x.EventLocations.FirstOrDefault()!.LocationId,
                    LocationDetails = new LocationDetails { Name = x.EventLocations.FirstOrDefault(y => y.Id == x.EventLocations.FirstOrDefault()!.Id)!.Location.Name }

                },
                EventActivityDto = new EventActivityDto
                {
                    Id = x.EventActivities.FirstOrDefault()!.Id,
                    ActivityId = x.EventActivities.FirstOrDefault()!.ActivityId,
                    ActivityDetails = new ActivityDetails { Name = x.EventActivities.FirstOrDefault(y => y.Id == x.EventActivities.FirstOrDefault()!.Id)!.Activity.Name }
                }



            }).ToListAsync();
            _dbContext.Commit();
            return data;
        }

        public async Task<UpdateEventDto> UpdateEvent(UpdateEventCommand request)
        {
            _dbContext.BeginTransaction();
            var @event = await _dbContext.Events
                                         .Include(x => x.EventLocations)
                                         .Include(x => x.EventActivities)
                                         .FirstOrDefaultAsync(x => x.EventId == request.EventId);

            if (@event == null)
            {
                throw new Exception("Event not found");
            }

            try
            {
                // Update event properties
                @event.Name = request.Name;
                @event.Price = request.Price;
                @event.Capacity = request.Capacity;
                @event.StartDate = request.StartDate;
                @event.EndDate = request.EndDate;
                @event.Description = request.Description;
                @event.ImageUrl = request.ImageUrl;
                @event.Highlights = request.Highlights;
                @event.EventRules = request.EventRules;
                @event.Status = request.Status;
                @event.IsDeleted = request.IsDeleted;
                @event.CampsiteId = request.CampsiteId;

                // Update EventLocations
                //foreach (var locationDto in request.EventLocationDTO)
                //{
                    var existingLocation = @event.EventLocations.FirstOrDefault(x => x.Id == request.EventLocationDTO.EventLocationId);

                    if (existingLocation != null)
                    {
                        existingLocation.LocationId = request.EventLocationDTO.LocationId;
                    }
                    else
                    {
                        var newLocation = new EventLocation
                        {
                            EventId = @event.EventId,
                            LocationId = request.EventLocationDTO.LocationId
                        };
                        _dbContext.EventLocations.AddAsync(newLocation);
                    }
                //}

                // Update EventActivities
                //foreach (var activityDto in request.EventActivityDTOs)
                //{
                    var existingActivity = @event.EventActivities.FirstOrDefault(x => x.Id == request.EventActivityDTO.EventActivityId);

                    if (existingActivity != null)
                    {
                        existingActivity.ActivityId = request.EventActivityDTO.ActivityId;
                    }
                    else
                    {
                        var newActivity = new EventActivities
                        {
                            EventId = @event.EventId,
                            ActivityId = request.EventActivityDTO.ActivityId
                        };
                        _dbContext.EventActivities.AddAsync(newActivity);
                    }
                //}

                await _dbContext.SaveChangesAsync();
                _dbContext.Commit();

                // Map updated event to DTO
                var updatedEventDto = new UpdateEventDto
                {
                    EventId = @event.EventId,
                    Name = @event.Name,
                    Price = @event.Price,
                    Capacity = @event.Capacity,
                    StartDate = @event.StartDate,
                    EndDate = @event.EndDate,
                    Description = @event.Description,
                    ImageUrl = @event.ImageUrl,
                    Highlights = @event.Highlights,
                    EventRules = @event.EventRules,
                    Status = @event.Status,
                    IsDeleted = @event.IsDeleted,
                    CampsiteId = @event.CampsiteId,
                    ActivityId= @event.EventActivities.FirstOrDefault()!.ActivityId,
                    LocationId=@event.EventLocations.FirstOrDefault()!.LocationId,
                    EventLocationDTO =  new EventLocationDTO
                    {
                        EventLocationId = @event.EventLocations.FirstOrDefault()!.Id,
                        LocationId = @event.EventLocations.FirstOrDefault()!.LocationId
                    },
                    EventActivityDTO =new EventActivityDTO
                    {
                        EventActivityId = @event.EventActivities.FirstOrDefault()!.Id,
                        ActivityId = @event.EventActivities.FirstOrDefault()!.ActivityId
                    }
                };

                return updatedEventDto;
            }
            catch (Exception ex)
            {
                _dbContext.Rollback();
                throw new Exception("An error occurred while updating the event", ex);
            }
        }


   
    }
}
