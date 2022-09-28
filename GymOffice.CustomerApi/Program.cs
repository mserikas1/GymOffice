using GymOffice.Business.Commands.AdministratorCommands.Add;
using GymOffice.Business.DataProviders;
using GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
using GymOffice.Common.Contracts.DataProviderContracts;
using GymOffice.Common.Contracts.RepositoryContracts;
using GymOffice.DataAccess.SQL;
using GymOffice.DataAccess.SQL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
// DI for Repositories
builder.Services.AddScoped<ICoachRepository, CoachRepository>();

// DI for DataProviders
builder.Services.AddScoped<ICoachDataProvider, CoachDataProvider>();
builder.Services.AddScoped<IAbonnementTypeRepository, AbonnementTypeRepository>();

//DI for DataProviders
builder.Services.AddScoped<IAbonnementTypeDataProvider, AbonnementTypeDataProvider>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseRouting();
app.UseCors(x =>
{
    x.AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowCredentials();
});
app.UseAuthorization();
app.MapControllers();

app.Run();
