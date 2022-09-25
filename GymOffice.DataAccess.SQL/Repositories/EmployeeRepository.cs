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

    public async Task AddAdministratorAsync(Admin admin)
    {
        await _dbContext.Admins.AddAsync(admin);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddReceptionistAsync(Receptionist receptionist)
    {
        await _dbContext.Receptionists.AddAsync(receptionist);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Admin?> GetAdministratorByIdAsync(Guid id)
    {
        return await _dbContext.Admins.FirstOrDefaultAsync(a => a.Id == id);
    }

    public ICollection<Admin>? GetAdministrators()
    {
        return _dbContext.Admins.ToList();
    }

    public async Task<ICollection<Admin>?> GetAdministratorsAsync()
    {
        return await _dbContext.Admins.ToListAsync();
    }

    public async Task<Receptionist?> GetReceptionistByIdAsync(Guid id)
    {
        return await _dbContext.Receptionists.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
    {
        return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
    }
}
