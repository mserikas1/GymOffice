var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<ApplicationDbContext>();

// DI for Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();

// DI for DataProviders
builder.Services.AddTransient<IEmployeeDataProvider, EmployeeDataProvider>();
builder.Services.AddTransient<ICoachDataProvider, CoachDataProvider>();
builder.Services.AddTransient<IVisitorDataProvider, VisitorDataProvider>();

// DI for Commands
builder.Services.AddTransient<IAddReceptionistCommand, AddReceptionistCommand>();
builder.Services.AddTransient<IEditReceptionistCommand, EditReceptionistCommand>();

builder.Services.AddMudServices();

// DI for Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();

// DI for DataProviders
builder.Services.AddTransient<ICoachDataProvider, CoachDataProvider>();
builder.Services.AddTransient<IEmployeeDataProvider, EmployeeDataProvider>();
builder.Services.AddTransient<IVisitorDataProvider, VisitorDataProvider>();

// DI for Commands
builder.Services.AddTransient<IAddCoachCommand, AddCoachCommand>();
builder.Services.AddTransient<IAddAdministratorCommand, AddAdministratorCommand>();
builder.Services.AddTransient<IAddReceptionistCommand, AddReceptionistCommand>();
builder.Services.AddTransient<IUpdateVisitorCommand, UpdateVisitorCommand>();
builder.Services.AddTransient<IUpdateCoachCommand, UpdateCoachCommand>();
builder.Services.AddTransient<IAddVisitorCardCommand, AddVisitorCardCommand>();
builder.Services.AddTransient<IAddVisitorCommand, AddVisitorCommand>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
