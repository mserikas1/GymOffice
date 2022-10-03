namespace GymOffice.DataAccess.SQL
{
    public class UserIdentityDbContext : IdentityDbContext
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options)
            : base(options)
        {
        }
    }
}