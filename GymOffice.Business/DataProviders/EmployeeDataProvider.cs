using GymOffice.Common.SearchParams;

namespace GymOffice.Business.DataProviders;

public class EmployeeDataProvider : IEmployeeDataProvider
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeDataProvider(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Admin?> GetAdministratorByIdAsync(Guid id)
    {
        return await _employeeRepository.GetAdministratorByIdAsync(id);
    }

    public ICollection<Admin>? GetAdministrators()
    {
        return _employeeRepository.GetAdministrators();
    }

    public async Task<ICollection<Admin>?> GetAdministratorsAsync()
    {
        return await _employeeRepository.GetAdministratorsAsync();
    }

    public async Task<Receptionist?> GetReceptionistByIdAsync(Guid id)
    {
        Receptionist? entity = await _employeeRepository.GetReceptionistByIdAsync(id);

        if (entity == null || entity.Id != id)
        {
            throw new NotFoundException(nameof(Receptionist), id);
        }

        return entity;
    }

    public async Task<ICollection<Receptionist>?> GetReceptionistsAsync()
    {
        return await _employeeRepository.GetReceptionistsAsync();
    }

    public async Task<ICollection<Receptionist>?> SearchReceptionistsAsync(ReceptionistSearchOptions options)
    {
        if (options == null)
        {
            return null;
        }
        if (options.IsNullOrEmpty())
        {
            return await _employeeRepository.GetReceptionistsAsync();
        }
        return await _employeeRepository.SearchReceptionistsAsync(options);
    }
}
