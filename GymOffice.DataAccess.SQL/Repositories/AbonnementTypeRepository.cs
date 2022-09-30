namespace GymOffice.DataAccess.SQL.Repositories;
public class AbonnementTypeRepository : IAbonnementTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AbonnementTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<AbonnementType>?> GetAllTypesAsync()
    {
        return await _dbContext.AbonnementTypes
            .Include(t => t.CreatedBy)
            .Include(t => t.ModifiedBy)
            .ToListAsync();
    }
}
