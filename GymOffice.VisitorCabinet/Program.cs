using GymOffice.Business.Commands.AdministratorCommands.Add;
using GymOffice.Business.Commands.EmployeeCommands.Add;
using GymOffice.Business.DataProviders;
using GymOffice.Common.Contracts.CommandContracts.EmployeeCommands.Add;
using GymOffice.Common.Contracts.DataProviderContracts;
using GymOffice.Common.Contracts.RepositoryContracts;
using GymOffice.Common.DTOs;
using GymOffice.DataAccess.SQL;
using GymOffice.DataAccess.SQL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<UserIdentityDbContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        RequireExpirationTime = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["token:audience"],
        ValidIssuer = builder.Configuration["token:issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["token:key"]))
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddDbContext<UserIdentityDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));


builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddTransient<IAddVisitorCommand, AddVisitorCommand>();
// DI for Repositories
builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<ICarouselPhotoRepository, CarouselPhotoRepository>();
builder.Services.AddScoped<IAbonnementTypeRepository, AbonnementTypeRepository>();
builder.Services.AddScoped<IGymRuleRepository, GymRuleRepository>();
builder.Services.AddScoped<IAdvantageRepository, AdvantageRepository>();

// DI for DataProviders
builder.Services.AddScoped<ICoachDataProvider, CoachDataProvider>();
builder.Services.AddScoped<ICarouselPhotoDataProvider, CarouselPhotoDataProvider>();
builder.Services.AddScoped<IAbonnementTypeDataProvider, AbonnementTypeDataProvider>();
builder.Services.AddScoped<IGymRulesDataProvider, GymRulesDataProvider>();
builder.Services.AddScoped<IAdvantageDataProvider, AdvantageDataProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(x =>
{
    x.AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowCredentials();
});
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
