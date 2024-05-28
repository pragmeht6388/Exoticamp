using Exoticamp.UI.Helper;
using Exoticamp.UI.Services.IRepositories;
using Exoticamp.UI.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var Configuration = builder.Configuration;

// ApiBaseUrl Keys
builder.Services.Configure<ApiBaseUrl>(Configuration.GetSection("ApiBaseUrl"));
builder.Services.AddScoped<IEventRepository,EventRepository>();
builder.Services.AddScoped<IChatbotRepository, ChatbotRepository>();
builder.Services.AddScoped<IUserQueryRepository, UserQueryRepository>();



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
