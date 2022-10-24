namespace GymOffice.DataAccess.SQL.Repositories;
public class VisitorRepository : IVisitorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VisitorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Visitor>?> GetAllVisitorsAsync()
    {
        return await _dbContext.Visitors
            .Include(v => v.VisitorCard)
            .ThenInclude(vc => vc.CreatedBy)
            .ToListAsync();
    }

    public async Task AddVisitorAsync(Visitor visitor)
    {
        await _dbContext.Visitors.AddAsync(visitor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<Visitor>?> GetVisitorsInGymAsync()
    {
        return await _dbContext.Visitors.Where(v => v.IsInGym)
            .Include(v => v.VisitorCard)
            .ThenInclude(vc => vc.CreatedBy)
            .ToListAsync();
    }
    public async Task<ICollection<Visitor>?> GetVisitorsNotInGymAsync()
    {
        return await _dbContext.Visitors.Where(v => !v.IsInGym)
            .Include(v => v.VisitorCard)
            .ThenInclude(vc => vc.CreatedBy)
            .ToListAsync();
    }
    public async Task<ICollection<Visitor>?> GetActiveVisitorsNotInGymAsync()
    {
        return await _dbContext.Visitors.Where(v => v.IsActive && !v.IsInGym)
            .Include(v => v.VisitorCard)
            .ThenInclude(vc => vc.CreatedBy)
            .ToListAsync();
    }

    public async Task<ICollection<Visitor>?> GetActiveVisitorsAsync()
    {
        return await _dbContext.Visitors.Where(v => v.IsActive)
            .Include(v => v.VisitorCard)
            .ThenInclude(vc => vc.CreatedBy)
            .ToListAsync();
    }

    public async Task<Visitor?> GetVisitorByIdAsync(Guid id)
    {
        return await _dbContext.Visitors
            .Include(v => v.VisitorCard)
            .ThenInclude(vc => vc.CreatedBy)
            .SingleOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Visitor?> GetVisitorByEmailAsync(string email)
    {
        return await _dbContext.Visitors
            .Include(v => v.VisitorCard)
            .ThenInclude(vc => vc.CreatedBy)
            .FirstOrDefaultAsync(v => v.Email == email);
    }

    public async Task<Visitor?> GetVisitorByPhoneAsync(string phoneNumber)
    {
        return await _dbContext.Visitors
            .Include(v => v.VisitorCard)
            .ThenInclude(vc => vc.CreatedBy)
            .FirstOrDefaultAsync(v => v.PhoneNumber == phoneNumber);
    }

    public async Task UpdateVisitorAsync(Visitor visitor)
    {
        Visitor? entity = await GetVisitorByIdAsync(visitor.Id);
        if (object.ReferenceEquals(visitor, entity))
        {
            _dbContext.Visitors.Update(visitor);
        }
        else
        {
            entity!.PhoneNumber = visitor.PhoneNumber;
            entity.IsActive = visitor.IsActive;
            entity.VisitorCard = visitor.VisitorCard;
            _dbContext.Visitors.Update(entity);
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddVisitorCardAsync(VisitorCard visitorCard)
    {
        _dbContext.VisitorCards.Add(visitorCard);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<VisitorCard?> GetVisitorCardByIdAsync(Guid id)
    {
        return await _dbContext.VisitorCards.SingleOrDefaultAsync(v => v.Id == id);
    }

    public async Task<ICollection<Visitor>?> SearchVisitorsAsync(VisitorSearchOptions options)
    {
        var visitors = _dbContext.Visitors
            .Include(v => v.VisitorCard)
            .ThenInclude(vc => vc.CreatedBy)
            .AsEnumerable();

        if (!string.IsNullOrEmpty(options.FirstName))
            visitors = visitors.Where(r => r.FirstName!.Contains(options.FirstName, StringComparison.InvariantCultureIgnoreCase));
        if (!string.IsNullOrEmpty(options.LastName))
            visitors = visitors.Where(r => r.LastName!.Contains(options.LastName, StringComparison.InvariantCultureIgnoreCase));
        if (!string.IsNullOrEmpty(options.Phone))
            visitors = visitors.Where(r => r.PhoneNumber!.Contains(options.Phone, StringComparison.InvariantCultureIgnoreCase));
        if (options.IsActive == SelectedItem.Selected)
            visitors = visitors.Where(r => r.IsActive == true);
        if (options.IsActive == SelectedItem.Unselected)
            visitors = visitors.Where(r => r.IsActive == false);
        if (options.IsInGym == SelectedItem.Selected)
            visitors = visitors.Where(r => r.IsInGym == true);
        if (options.IsInGym == SelectedItem.Unselected)
            visitors = visitors.Where(r => r.IsInGym == false);
        if (options.HasGroupTraining == SelectedItem.Selected)
            visitors = visitors.Where(r => r.GroupTrainings.Any());
        if (options.HasGroupTraining == SelectedItem.Unselected)
            visitors = visitors.Where(r => r.GroupTrainings == null || r.GroupTrainings.Any() == false);

        return await Task.FromResult(visitors.ToList());
    }
}
