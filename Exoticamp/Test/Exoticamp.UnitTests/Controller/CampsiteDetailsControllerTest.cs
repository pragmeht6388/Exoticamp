using Xunit;
using Moq;
using Shouldly;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails;

using System.Threading;
using System.Threading.Tasks;
using Exoticamp.Api.Controllers.v1;
using Exoticamp.Application.Responses;
using Microsoft.Extensions.Logging;
using System;
using Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite;
using Exoticamp.Application.Features.CampsiteDetails.Commands.DeleteCampsiteDetails;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using AutoMapper.Features;

namespace Exoticamp.Tests
{
    public class CampsiteControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<CampsiteDetailsController>> _loggerMock;
        private readonly CampsiteDetailsController _controller;

        public CampsiteControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<CampsiteDetailsController>>();
            _controller = new CampsiteDetailsController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithCreatedCampsite()
        {
            // Arrange
            var command = new AddCampsiteDetailsCommand
            {
                Name = "Test Campsite",
                Location = "Location",
                Status = true,
                TentType = "Test Tent",
                Images = "test.jpg",
                DateTime = DateTime.Now,
                Highlights = "Test Highlights",
                Ratings = "5",
                AboutCampsite = "Test About",
                CampsiteRules = "Test Rules",
                BestTimeToVisit = "Anytime",
                HowToGetHere = "Test Directions",
                QuickSummary = "Quick Summary",
               
                MealPlans = "Test Meal Plans",
                Itinerary = "Test Itinerary",
                Inclusions = "Test Inclusions",
                Exclusion = "Test Exclusion",
                Amenities = "Test Amenities",
                Accommodation = "Test Accommodation",
                Safety = "Test Safety",
                DistanceWithMap = "Test Map",
                WhyExoticamp = "Test Why",
                FAQs = "Test FAQs",
                HouseRules = "Test House Rules",
                CancellationPolicy = "Test Policy",
                isActive = true,
                //isDeleted=false
            };

            var responseDto = new CampsiteDetailsDto
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Location = command.Location,
                Status = command.Status,
                TentType = command.TentType,
                Images = command.Images,
                DateTime = command.DateTime,
                Highlights = command.Highlights,
                Ratings = command.Ratings,
                AboutCampsite = command.AboutCampsite,
                CampsiteRules = command.CampsiteRules,
                BestTimeToVisit = command.BestTimeToVisit,
                HowToGetHere = command.HowToGetHere,
                QuickSummary = command.QuickSummary,
               
                MealPlans = command.MealPlans,
                Itinerary = command.Itinerary,
                Inclusions = command.Inclusions,
                Exclusion = command.Exclusion,
                Amenities = command.Amenities,
                Accommodation = command.Accommodation,
                Safety = command.Safety,
                DistanceWithMap = command.DistanceWithMap,
                WhyExoticamp = command.WhyExoticamp,
                FAQs = command.FAQs,
                HouseRules = command.HouseRules,
                CancellationPolicy = command.CancellationPolicy,
                isActive = command.isActive,
                //isDeleted= command.isDeleted,
            };

            var response = new Response<CampsiteDetailsDto>
            {
                Data = responseDto,
                Message = "Success",
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<AddCampsiteDetailsCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedResponse = okResult.Value as Response<CampsiteDetailsDto>;
            Assert.NotNull(returnedResponse);
            Assert.True(returnedResponse.Succeeded);
            Assert.Equal(responseDto.Id, returnedResponse.Data.Id);
            Assert.Equal(responseDto.Name, returnedResponse.Data.Name);
            Assert.Equal(responseDto.Location, returnedResponse.Data.Location);
            Assert.Equal(responseDto.Status, returnedResponse.Data.Status);
            Assert.Equal(responseDto.TentType, returnedResponse.Data.TentType);
            Assert.Equal(responseDto.Images, returnedResponse.Data.Images);
            Assert.Equal(responseDto.DateTime, returnedResponse.Data.DateTime);
            Assert.Equal(responseDto.Highlights, returnedResponse.Data.Highlights);
            Assert.Equal(responseDto.Ratings, returnedResponse.Data.Ratings);
            Assert.Equal(responseDto.AboutCampsite, returnedResponse.Data.AboutCampsite);
            Assert.Equal(responseDto.CampsiteRules, returnedResponse.Data.CampsiteRules);
            Assert.Equal(responseDto.BestTimeToVisit, returnedResponse.Data.BestTimeToVisit);
            Assert.Equal(responseDto.HowToGetHere, returnedResponse.Data.HowToGetHere);
            Assert.Equal(responseDto.QuickSummary, returnedResponse.Data.QuickSummary);
            Assert.Equal(responseDto.CategoryId, returnedResponse.Data.CategoryId);
            Assert.Equal(responseDto.ActivitiesId, returnedResponse.Data.ActivitiesId);
            Assert.Equal(responseDto.MealPlans, returnedResponse.Data.MealPlans);
            Assert.Equal(responseDto.Itinerary, returnedResponse.Data.Itinerary);
            Assert.Equal(responseDto.Inclusions, returnedResponse.Data.Inclusions);
            Assert.Equal(responseDto.Exclusion, returnedResponse.Data.Exclusion);
            Assert.Equal(responseDto.Amenities, returnedResponse.Data.Amenities);
            Assert.Equal(responseDto.Accommodation, returnedResponse.Data.Accommodation);
            Assert.Equal(responseDto.Safety, returnedResponse.Data.Safety);
            Assert.Equal(responseDto.DistanceWithMap, returnedResponse.Data.DistanceWithMap);
            Assert.Equal(responseDto.WhyExoticamp, returnedResponse.Data.WhyExoticamp);
            Assert.Equal(responseDto.FAQs, returnedResponse.Data.FAQs);
            Assert.Equal(responseDto.HouseRules, returnedResponse.Data.HouseRules);
            Assert.Equal(responseDto.CancellationPolicy, returnedResponse.Data.CancellationPolicy);
            Assert.Equal(responseDto.isActive, returnedResponse.Data.isActive);
            //Assert.Equal(responseDto.isDeleted, returnedResponse.Data.isDeleted);

        }


        [Fact]
        public async Task UpdateById_ReturnsOkResult_WithUpdatedCampsite()
        {
            // Arrange
            var command = new UpdateCampsiteDetailsCommand
            {
                Id = Guid.NewGuid(),
                Name = "Updated Campsite",
                Location = "Location",
                Status = true,
                TentType = "Updated Tent",
                Images = "updated.jpg",
                DateTime = DateTime.Now,
                Highlights = "Updated Highlights",
                Ratings = "4",
                AboutCampsite = "Updated About",
                CampsiteRules = "Updated Rules",
                BestTimeToVisit = "Winter",
                HowToGetHere = "Updated Directions",
                QuickSummary = "Updated Summary",
                CategoryId = Guid.NewGuid(),
                ActivitiesId = Guid.NewGuid(),
                MealPlans = "Updated Meal Plans",
                Itinerary = "Updated Itinerary",
                Inclusions = "Updated Inclusions",
                Exclusion = "Updated Exclusion",
                Amenities = "Updated Amenities",
                Accommodation = "Updated Accommodation",
                Safety = "Updated Safety",
                DistanceWithMap = "Updated Map",
                WhyExoticamp = "Updated Why",
                FAQs = "Updated FAQs",
                HouseRules = "Updated House Rules",
                CancellationPolicy = "Updated Policy",
                isActive = true,
                //isDeleted=false
            };

            var responseDto = new UpdateCampsiteDetailsDto
            {
                Id = command.Id,
                Name = command.Name,
                Location = command.Location,
                Status = command.Status,
                TentType = command.TentType,
                Images = command.Images,
                DateTime = command.DateTime,
                Highlights = command.Highlights,
                Ratings = command.Ratings,
                AboutCampsite = command.AboutCampsite,
                CampsiteRules = command.CampsiteRules,
                BestTimeToVisit = command.BestTimeToVisit,
                HowToGetHere = command.HowToGetHere,
                QuickSummary = command.QuickSummary,
                CategoryId = command.CategoryId,
                ActivitiesId = command.ActivitiesId,
                MealPlans = command.MealPlans,
                Itinerary = command.Itinerary,
                Inclusions = command.Inclusions,
                Exclusion = command.Exclusion,
                Amenities = command.Amenities,
                Accommodation = command.Accommodation,
                Safety = command.Safety,
                DistanceWithMap = command.DistanceWithMap,
                WhyExoticamp = command.WhyExoticamp,
                FAQs = command.FAQs,
                HouseRules = command.HouseRules,
                CancellationPolicy = command.CancellationPolicy,
                isActive = command.isActive,
                //isDeleted=false
            };

            var response = new Response<UpdateCampsiteDetailsDto>
            {
                Data = responseDto,
                Succeeded = true,
                Message = "Campsite updated successfully"
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateCampsiteDetailsCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.UpdateById(command);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedResponse = okResult.Value as Response<UpdateCampsiteDetailsDto>;
            Assert.NotNull(returnedResponse);
            Assert.True(returnedResponse.Succeeded);
            Assert.Equal(responseDto.Id, returnedResponse.Data.Id);
            Assert.Equal(responseDto.Name, returnedResponse.Data.Name);
            Assert.Equal(responseDto.Location, returnedResponse.Data.Location);
        }

        

       

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenCampsiteExists()
        {
            // Arrange
            var campsiteId = "existing-campsite-id";

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteCampsiteDetailsCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);

            // Act
            var result = await _controller.Delete(campsiteId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

       

        [Fact]
        public async Task GetAllCampsite_ReturnsOkResult_WithCampsiteDetails()
        {
            // Arrange
            var campsiteDetails = new List<CampsiteDetailsVM>
            {
                new CampsiteDetailsVM
                {
                    Id = Guid.NewGuid(),
                    Name = "Campsite 1",
                    Location = "Location",
                    Status = true,
                    TentType = "Tent Type 1",
                    Images = "Image 1",
                    DateTime = DateTime.UtcNow,
                    Highlights = "Highlights 1",
                    Ratings = "5 stars",
                    AboutCampsite = "About 1",
                    CampsiteRules = "Rules 1",
                    BestTimeToVisit = "Best Time 1",
                    HowToGetHere = "Directions 1",
                    QuickSummary = "Summary 1",
                    //CategoryId = Guid.NewGuid(),
                    //CategoryName = "Category 1",
                    //ActivitiesId = Guid.NewGuid(),
                    //ActivitiesName = "Activity 1",
                    MealPlans = "Meal Plan 1",
                    Itinerary = "Itinerary 1",
                    Inclusions = "Inclusions 1",
                    Exclusion = "Exclusions 1",
                    Amenities = "Amenities 1",
                    Accommodation = "Accommodation 1",
                    Safety = "Safety 1",
                    DistanceWithMap = "Map 1",
                    WhyExoticamp = "Why Exoticamp 1",
                    FAQs = "FAQs 1",
                    HouseRules = "House Rules 1",
                    CancellationPolicy = "Policy 1",
                    isActive = true,
                    //isDeleted=false,
                    ApprovedBy = "Admin",
                    ApprovededDate = DateTime.UtcNow,
                    DeletededBy = null,
                    DeletedDate = null
                }
            };

            var response = new Response<IEnumerable<CampsiteDetailsVM>>
            {
                Data = campsiteDetails,
                Message = "Success",
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetCampsiteDetailsListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.GetAllCampsite();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedResponse = okResult.Value as Response<IEnumerable<CampsiteDetailsVM>>;
            Assert.NotNull(returnedResponse);
            Assert.True(returnedResponse.Succeeded);
            Assert.Equal(response.Data, returnedResponse.Data);
        }

        [Fact]
        public async Task GetAllCampsite_LogsAppropriateMessages()
        {
            // Arrange
            var campsiteDetails = new List<CampsiteDetailsVM>
            {
                new CampsiteDetailsVM
                {
                    Id = Guid.NewGuid(),
                    Name = "Campsite 1",
                    Location ="Location", 
                    Status = true,
                    TentType = "Tent Type 1"
                    // Other properties...
                }
            };

            var response = new Response<IEnumerable<CampsiteDetailsVM>>
            {
                Data = campsiteDetails,
                Message = "Success",
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetCampsiteDetailsListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            await _controller.GetAllCampsite();

            // Assert
            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("GetAllCampsite Initiated")),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);

            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("GetAllCampsite Completed")),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        
    }
}