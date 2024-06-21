using AutoMapper;
using Exoticamp.Application.Features.Categories.Commands.CreateCategory;
using Exoticamp.Application.Features.Categories.Commands.StoredProcedure;
using Exoticamp.Application.Features.Categories.Commands.UpdateCategory;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Exoticamp.Application.Features.Categories.Queries.GetCategory;
using Exoticamp.Application.Features.Events.Commands.CreateEvent;
using Exoticamp.Application.Features.Events.Commands.Transaction;
using Exoticamp.Application.Features.Events.Commands.UpdateEvent;
using Exoticamp.Application.Features.Events.Queries.GetEventDetail;
using Exoticamp.Application.Features.Events.Queries.GetEventsExport;
using Exoticamp.Application.Features.Events.Queries.GetEventsList;
using Exoticamp.Application.Features.Orders.Queries.GetOrdersForMonth;
using Exoticamp.Application.Features.Products.Commands.AddProduct;
using Exoticamp.Application.Features.Products.Commands.UpdateProduct;
using Exoticamp.Domain.Entities;
using Exoticamp.Application.Features.Products.Queries.GetProduct;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Application.Features.Users.Queries.GetUserList;
using Exoticamp.Application.Features.Banners.Queries;
using Exoticamp.Application.Features.Banners.Commands.CreateBanner;
using Exoticamp.Application.Features.Banners.Queries.GetBanner;
using Exoticamp.Application.Features.Banners.Commands.UpdateBanner;
using Exoticamp.Application.Features.ContactUs.Command.AddContactUs;
using Exoticamp.Application.Features.ContactUs.Query.GetContactUs;
using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using Exoticamp.Application.Features.Campsite.Commands.UpdateCampsite;
using Exoticamp.Application.Features.Campsite.Query.GetCampsiteList;
using Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails;
using Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails;
using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Features.Activities.Commands.UpdateActivities;
using Exoticamp.Application.Features.UserQueries.Commands.CreateUserQuery;
using Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryList;
using Exoticamp.Application.Features.Vendors.Queries.GetVendorList;
using Exoticamp.Application.Features.Users.Commands.DeleteUser;
using Exoticamp.Application.Features.Users.Queries.GetUser;
using Exoticamp.Application.Features.Users.Commands.UpdateUser;
using Exoticamp.Application.Features.Locations.Queries;
using Exoticamp.Application.Features.Locations.Queries.GetLocation;

using CDVM = Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteByLocationId.CampsiteDetailsVM1;
using Exoticamp.Application.Features.Reviews.Commands.AddReviews;
using Exoticamp.Application.Features.Reviews.Queryies.GetReviewList;
using Exoticamp.Application.Features.RewiewReply.Command.AddReviewReply;
using Exoticamp.Application.Features.Reviews.Queryies.GetReviewById;
using Exoticamp.Application.Features.Reviews.Commands.UpdateReviews;
using Exoticamp.Application.Features.Vendors.Queries.GetVendor;
using Exoticamp.Application.Features.Vendors.Commands.UpdateVendor;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Features.RewiewReply.Query.GetReplyById;
using Exoticamp.Application.Features.RewiewReply.Query.GetReplyList;

using Exoticamp.Application.Features.Bookings.Commands.AddBooking;
using Exoticamp.Application.Features.Bookings.Queries.GetBookingList;
using Exoticamp.Application.Features.Bookings.Queries.GetBookingDetails;
using Exoticamp.Application.Features.Bookings.Commands.UpdateBooking;
using Exoticamp.Application.Features.Glamping.GetGlamping;
using Exoticamp.Application.Features.Glamping.GetGlampingList;

namespace Exoticamp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, CreateEventCommandDto>().ReverseMap();

            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, TransactionCommandDto>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<UpdateEventCommand,UpdateEventDto>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            //CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryVM>();

            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();

            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<Product, AddProductCommand>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<Product, Features.Products.Queries.GetProductList.ProductVM>();

            CreateMap<Product, Features.Products.Queries.GetProduct.ProductVM>();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Banner, CreateBannerCommand>().ReverseMap();
            CreateMap<Banner, CreateBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerCommand>().ReverseMap();

            CreateMap<Banner, BannerDto>().ReverseMap();
            CreateMap<UserQuery, CreateUserQueryCommand>().ReverseMap();
            CreateMap<UserQuery, GetUserQueryListVM>().ReverseMap();


            CreateMap<Banner, BannerVM>();
            CreateMap<ContactUs, AddContactUsCommand>().ReverseMap();
            CreateMap<ContactUs, ContactUsDto>();
            CreateMap<ContactUs,ContactUsVM>();

            CreateMap<Campsite,AddCampsiteCommand>().ReverseMap();
            CreateMap<Campsite,CampsiteDto>();
            CreateMap<Campsite, UpdateCampsiteCommand>().ReverseMap();
            CreateMap<Campsite, Features.Campsite.Query.GetCampsiteList.CampsiteVM>();
            CreateMap<Campsite, Features.Campsite.Query.GetCampsite.CampsiteVM>();

            CreateMap<CampsiteDetails,AddCampsiteDetailsCommand>().ReverseMap();
            CreateMap<CampsiteDetails,CampsiteDetailsDto>();
            CreateMap<CampsiteDetails, UpdateCampsiteDetailsCommand>().ReverseMap();
            CreateMap<CampsiteDetails, Features.CampsiteDetails.Query.GetCampsiteDetailsList.CampsiteDetailsVM>().ReverseMap();
            CreateMap<CampsiteDetails, Features.CampsiteDetails.Query.GetCampsiteDetails.CampsiteDetailsVM>();
            CreateMap<Location,GetLocationListVM>().ReverseMap();
            CreateMap<Location,LocationVM>().ReverseMap();
            CreateMap<Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList.CampsiteDetailsVM, CDVM>().ReverseMap();

            CreateMap<Activities, AddCampsiteCommand>().ReverseMap();
            CreateMap<Activities,ActivityDto>().ReverseMap();
            CreateMap<Activities, UpdateActivitiesCommand>().ReverseMap();
            CreateMap<Activities, Features.Activities.Query.GetActivityList.ActivityVM>().ReverseMap();


            CreateMap< RegistrationRequest, GetUserListDto>().ReverseMap();
            CreateMap<RegistrationRequest,  GetVendorListDto>().ReverseMap();
             

            CreateMap<RegistrationRequest, GetUserDto>().ReverseMap();
            CreateMap<GetVendorListDto,  GetVendorListQuery>().ReverseMap();
            CreateMap<GetVendorListDto, GetUserListQuery>().ReverseMap();
            CreateMap<UpdateUserProfileCommand, GetUserDto>().ReverseMap();
            CreateMap<GetLocationListVM, Location>().ReverseMap();

            CreateMap<GetVendorQueryByIdQuery, GetVendorDto>().ReverseMap();

            CreateMap<Reviews,AddReviewCommand>().ReverseMap();
            CreateMap<Reviews, ReviewDto>().ReverseMap();
            CreateMap<Reviews,ReviewVM>().ReverseMap();
            CreateMap<Reviews, ReviewsVM>().ReverseMap();
            CreateMap<Reviews,UpdateReviewCommand>().ReverseMap();

            CreateMap<ReviewReply,ReviewReplyDto>().ReverseMap();
            CreateMap<ReviewReply,AddReviewReplyCommand>().ReverseMap();
            CreateMap<UpdateVendorCommand, UpdatedVendorDto>().ReverseMap();


            CreateMap<Booking, CreateBookingCommand>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, BookingVM>().ReverseMap();
            CreateMap<Booking,GetBookingByIdDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingCommand>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
             
                 CreateMap<Glamping, GlampingDto>().ReverseMap();
            CreateMap<Glamping, GetGlampingListDto>().ReverseMap();
        }


    }
}
