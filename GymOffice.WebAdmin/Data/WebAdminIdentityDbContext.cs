namespace GymOffice.WebAdmin.Data
{
    public class WebAdminIdentityDbContext : IdentityDbContext
    {
        public WebAdminIdentityDbContext(DbContextOptions<WebAdminIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GymWebAdminDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}