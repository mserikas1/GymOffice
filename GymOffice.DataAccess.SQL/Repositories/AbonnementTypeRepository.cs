namespace GymOffice.DataAccess.SQL.Repositories;
public class AbonnementTypeRepository : IAbonnementTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AbonnementTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddTypeAsync(AbonnementType type)
    {
        await _dbContext.AbonnementTypes.AddAsync(type);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<AbonnementType>?> GetAllTypesAsync()
    {
        return await _dbContext.AbonnementTypes
            .Include(t => t.CreatedBy)
            .Include(t => t.ModifiedBy)
            .ToListAsync();
    }

    public async Task<AbonnementType?> GetByIdAsync(Guid id)
    {
        return await _dbContext.AbonnementTypes
            .Include(t => t.CreatedBy)
            .Include(t => t.ModifiedBy)
            .SingleOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateTypeAsync(AbonnementType type)
    {
        AbonnementType? entity = await GetByIdAsync(type.Id);
        if (entity == null) return;

        entity.ModifiedBy = type.ModifiedBy;
        entity.ModifiedAt = type.ModifiedAt;
        entity.Price = type.Price;
        entity.Description = type.Description;
        entity.IsActive = type.IsActive;
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
    public ICollection<AbonnementType>? GetActiveAbonnementTypes()
    {
        return _dbContext.AbonnementTypes.Where(abonnement => abonnement.IsActive == true).ToList();
    }
}
