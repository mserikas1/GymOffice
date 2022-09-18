using GymOffice.Common.Contracts.RepositoryContracts;
using GymOffice.Common.DTOs;
using Microsoft.EntityFrameworkCore;

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
        _dbContext.SaveChanges();
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
        return await _dbContext.Receptionists.SingleOrDefaultAsync(a => a.Id == id);
    }
}
