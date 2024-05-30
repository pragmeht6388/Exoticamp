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

namespace Exoticamp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
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

            //users
            CreateMap<RegistrationRequest, GetUserListDto>().ReverseMap();
            


        }
    }
}
