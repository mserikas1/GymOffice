namespace GymOffice.DataAccess.SQL.Repositories;
public class VisitorRepository : IVisitorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VisitorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Visitor>?> GetVisitorsAsync()
    {
        return await _dbContext.Visitors.Include(v => v.VisitorCard).ToListAsync();
    }
}
