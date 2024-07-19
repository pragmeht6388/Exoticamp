using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Persistence.Repositories;

namespace Exoticamp.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped< IUserRepository,  UserRepository>();
            services.AddScoped<IBannerRepository, BannerRepository>();

            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<ICampsiteRepository, CampsiteRepository>();
            services.AddScoped<ICampsiteDetailsRepository, CampsiteDetailsRepository>();
            services.AddScoped<IActivitiesRepository,ActivityRepository>();
            services.AddScoped<ILoactionRepository,LocationRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewReplyRepository, ReviewReplyRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ITentRepository, TentRepository>();
            services.AddScoped<ICartCampRepository, CartCampRepository>();
            services.AddScoped<ICustomerOtpRepository, CustomerOtpRepository>();
            services.AddScoped<ICustomerConsentRepository,CustomerConsentRepository>();
            services.AddScoped<ICustomerMPINRepository, CustomerMPINRepository>();
            //services.AddScoped<ITentAvailabilityRepository, TentRepository>();
            return services;
        }
    }
}
