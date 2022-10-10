var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<ApplicationDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("GymOffice.DataAccess.SQL")
     ));

builder.Services.AddDbContext<UserIdentityDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<UserIdentityDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

// example of Razor Identity Pages setup
// https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings - this should correspond to the settings for passwords in Coach's and Receptionist's view models
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = false;

    // User settings
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;

    options.SignIn.RequireConfirmedAccount = false; // require confirmed account for sign in
    options.SignIn.RequireConfirmedEmail = false; // require email validation for sign in
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.Name = "_GymOfficeStaff";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(8);

    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    // options.AccessDeniedPath = "/Identity/Pages/Account/AccessDenied"; // this is default, so not needed, it is here to show the link
    options.SlidingExpiration = true;
});

// If we do so, only registered users with these roles will be able to login and use the App
builder.Services.AddAuthorization(options => {
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        //.RequireAuthenticatedUser()   // this is for ANY role, that is, to require login
        .RequireRole("Admin", "Receptionist", "Coach") // Login, Logout and AccessDenied pages should be set [AllowAnonymous] to avoid cyclic reference
        .Build();
});

builder.Services.AddMudServices();

// DI for Repositories
builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<ICarouselPhotoRepository, CarouselPhotoRepository>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<IAbonnementTypeRepository, AbonnementTypeRepository>();
builder.Services.AddScoped<IAbonnementRepository, AbonnementRepository>();

// DI for DataProviders
builder.Services.AddTransient<ICoachDataProvider, CoachDataProvider>();
builder.Services.AddTransient<IEmployeeDataProvider, EmployeeDataProvider>();
builder.Services.AddTransient<IVisitorDataProvider, VisitorDataProvider>();
builder.Services.AddTransient<ICarouselPhotoDataProvider, CarouselPhotoDataProvider>();
builder.Services.AddTransient<IAbonnementTypeDataProvider, AbonnementTypeDataProvider>();
builder.Services.AddTransient<IAbonnementDataProvider, AbonnementDataProvider>();

// DI for Commands
builder.Services.AddTransient<IAddCoachCommand, AddCoachCommand>();
builder.Services.AddTransient<IAddAdministratorCommand, AddAdministratorCommand>();
builder.Services.AddTransient<IAddReceptionistCommand, AddReceptionistCommand>();
builder.Services.AddTransient<IEditCoachCommand, EditCoachCommand>();
builder.Services.AddTransient<IEditVisitorCommand, EditVisitorCommand>();
builder.Services.AddTransient<IEditReceptionistCommand, EditReceptionistCommand>();
builder.Services.AddTransient<IUpdateVisitorCommand, UpdateVisitorCommand>();
builder.Services.AddTransient<IUpdateCoachCommand, UpdateCoachCommand>();
builder.Services.AddTransient<IAddVisitorCardCommand, AddVisitorCardCommand>();
builder.Services.AddTransient<IAddVisitorCommand, AddVisitorCommand>();
builder.Services.AddTransient<IAddAbonnementTypeCommand, AddAbonnementTypeCommand>();
builder.Services.AddTransient<IEditAbonnementTypeCommand, EditAbonnementTypeCommand>();
builder.Services.AddTransient<IAddCarouselPhotoCommand, AddCarouselPhotoCommand>();
builder.Services.AddTransient<IEditCarouselPhotoCommand, EditCarouselPhotoCommand>();
builder.Services.AddTransient<IDeleteCarouselPhotoCommand, DeleteCarouselPhotoCommand>();

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

app.UseAuthentication();
app.UseAuthorization();

app.Run();