using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;
using Exoticamp.Persistence;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Exoticamp.Application.Features.Events.Commands.CreateEvent;
using System.Diagnostics;
using Exoticamp.Application.Exceptions;

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
               
              var campsites= await _dbContext.Set<CampsiteDetails>().ToListAsync();
               var campsite= campsites.FirstOrDefault(x=>x.Id==request.CampsiteId);
                var activities= await _dbContext.Set<Activities>().ToListAsync();
                var activity = activities.FirstOrDefault(x => x.Id == request.ActivityId);
                var locations= await _dbContext.Set<Location>().ToListAsync();
                var location = locations.FirstOrDefault(x => x.Id == request.locationId);

                
                
                   
                

                if (campsite != null)
                {
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
                    await _dbContext.SaveChangesAsync();

                    if (activity!=null)
                    {
                        var eventActivities = new EventActivities()
                        {
                            ActivityId = request.ActivityId,

                            EventId = request.EventId,
                            Event=@event,
                            Activity=activity
                        };
                        await _dbContext.Set<EventActivities>().AddAsync(eventActivities);
                        await _dbContext.SaveChangesAsync();
                    }
                    else { throw new NotFoundException("Activity not found", @event); }
                    if (location!=null)
                    {
                        var eventLocation = new EventLocation()
                        {
                            LocationId = request.locationId,
                            EventId = @event.EventId,
                            Location=location,
                            Event=@event

                        };
                        await _dbContext.Set<EventLocation>().AddAsync(eventLocation);
                        await _dbContext.SaveChangesAsync();
                    }
                    else { throw new NotFoundException("Location not found", @event); }

                    _dbContext.Commit();
                }
                else
                {
                    //@event.Name = request.Name;
                    //@event.Price = request.Price;
                    //@event.Capacity = request.Capacity;
                    //@event.StartDate = request.StartDate;
                    //@event.EndDate = request.EndDate;
                    //@event.Description = request.Description;
                    //@event.ImageUrl = request.ImageUrl;
                    //@event.Highlights = request.Highlights;
                    //@event.EventRules = request.EventRules;
                    //@event.Status = request.Status;
                    //@event.IsDeleted = request.IsDeleted;
                    //    await _dbContext.Set<Campsite>().AddAsync(@event.Campsite);
                    //    await _dbContext.SaveChangesAsync();
                    //    @event.CampsiteId = @event.Campsite.CategoryId;

                    throw new NotFoundException("Campsite not found",@event);
                }
               

              
                //return @event;
             

            }
            catch (Exception ex)
            {

                _dbContext.Rollback();
            }
            return @event;
        }

    }
}
