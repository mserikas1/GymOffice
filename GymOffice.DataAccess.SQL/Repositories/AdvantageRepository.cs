using GymOffice.Common.DTOs;
using GymOffice.Common.SearchParams;
using GymOffice.Common.Utilities.Enums;

namespace GymOffice.DataAccess.SQL.Repositories;
public class AdvantageRepository : IAdvantageRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AdvantageRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAdvantageAsync(Advantage advantage)
    {
        await _dbContext.Advantages.AddAsync(advantage);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Advantage?> GetAdvantageByIdAsync(Guid id)
    {
        return await _dbContext.Advantages.SingleOrDefaultAsync(a => a.Id == id);
    }

    public async Task<ICollection<Advantage>?> GetAdvantagesAsync()
    {
        return await _dbContext.Advantages.ToListAsync();
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<ICollection<Advantage>?> SearchAdvantagesAsync(AdvantageSearchOptions options)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {        
        var advantages = _dbContext.Advantages
            .Include(r => r.CreatedBy)
            .Include(r => r.ModifiedBy).AsEnumerable();

        if (!string.IsNullOrEmpty(options.Title))
            advantages = advantages.Where(r => r.Title.Contains(options.Title, StringComparison.InvariantCultureIgnoreCase));
        
        return advantages.ToList();
    }

    public async Task UpdateAdvantageAsync(Advantage advantage)
    {
        Advantage? entity = await _dbContext.Advantages
            .SingleOrDefaultAsync(r => r.Id == advantage.Id);
        if (entity != null)
        {
            entity.Description = advantage.Description;
            entity.Title = advantage.Title;
            entity.PhotoUrl = advantage.PhotoUrl;
            entity.ModifiedBy = advantage.ModifiedBy;
            entity.ModifiedAt = advantage.ModifiedAt;
            await _dbContext.SaveChangesAsync();
        }
    }
}
