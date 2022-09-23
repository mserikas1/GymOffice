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
        var admins = await _employeeRepository.GetAdministratorsAsync();
        return admins;
    }

    public async Task<ICollection<Receptionist>?> GetReceptionistsAsync()
    {
        return await _employeeRepository.GetReceptionistsAsync();
    }
}
