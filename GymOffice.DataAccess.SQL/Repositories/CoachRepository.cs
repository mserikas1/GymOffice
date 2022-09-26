namespace GymOffice.DataAccess.SQL.Repositories;
public class CoachRepository : ICoachRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CoachRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Coach>?> GetAllCoachesAsync()
    {
        return await _dbContext.Coaches.ToListAsync();
    }
}
