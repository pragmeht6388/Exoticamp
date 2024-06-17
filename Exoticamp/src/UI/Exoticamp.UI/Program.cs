using Exoticamp.UI.Helper;
using Exoticamp.UI.Services.IRepositories;
using Exoticamp.UI.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;  
    options.Cookie.IsEssential = true;  
});
var Configuration = builder.Configuration;
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// ApiBaseUrl Keys
builder.Services.Configure<ApiBaseUrl>(Configuration.GetSection("ApiBaseUrl"));
builder.Services.AddScoped<IEventRepository,EventRepository>();
builder.Services.AddScoped< IRegistrationRepository,  RegistrationRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILocationRepository , LocationRepository>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();




builder.Services.AddScoped<IBannerRepository,BannerRepository>();
builder.Services.AddScoped<ILocationRepository,LocationRepository>();
builder.Services.AddScoped<IContactUsRepository,ContactUsRepository>();
builder.Services.AddScoped<ICampsiteRepository, CamsiteRepository>();
builder.Services.AddScoped<IChatbotRepository, ChatbotRepository>();
builder.Services.AddScoped<IUserQueryRepository, UserQueryRepository>();


builder.Services.AddScoped<ICampsiteDetailsRepository, CampsiteDetailsRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IReviewsRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewReplyRepository,ReviewReplyRepositories>();
builder.Services.AddScoped<IVendorRepository, VendorsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
