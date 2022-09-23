namespace GymOffice.DataAccess.SQL.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddReceptionistAsync(Receptionist receptionist)
    {
        await _dbContext.Receptionists.AddAsync(receptionist);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Admin?> GetAdministratorByIdAsync(Guid id)
    {
        return await _dbContext.Admins.SingleOrDefaultAsync(a => a.Id == id);
    }

    public ICollection<Admin>? GetAdministrators()
    {
        return _dbContext.Admins.ToList();
    }

    public async Task<ICollection<Admin>?> GetAdministratorsAsync()
    {
        var admins = await _dbContext.Admins.ToListAsync();
        return admins;
    }

    public async Task<Receptionist?> GetReceptionistByIdAsync(Guid id)
    {
        return await _dbContext.Receptionists.SingleOrDefaultAsync(r => r.Id == id);
    }

    public async Task<ICollection<Receptionist>?> GetReceptionistsAsync()
    {
        return await _dbContext.Receptionists
            .Include(r => r.CreatedBy)
            .Include(r => r.ModifiedBy)
            .ToListAsync();
    }

    public async Task UpdateReceptionistAsync(Receptionist receptionist)
    {
        Receptionist? entity = await _dbContext.Receptionists
            .SingleOrDefaultAsync(r => r.Id == receptionist.Id);
        if (entity != null)
        {
            entity.PhoneNumber = receptionist.PhoneNumber;
            entity.Email = receptionist.Email;
            entity.IsActive = receptionist.IsActive;
            entity.ModifiedBy = receptionist.ModifiedBy;
            entity.ModifiedAt = receptionist.ModifiedAt;
            entity.PhotoUrl = receptionist.PhotoUrl;
            _dbContext.Receptionists.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
