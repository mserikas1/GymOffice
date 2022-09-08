namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>?> GetEmployeesAsync();
    Task<Employee?> GetEmployeeByIdAsync(Guid id);
    Task<Guid> AddEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(Employee employee);
    Task<Employee> DeleteEmployeeAsync(Guid id);
    Task<IEnumerable<Receptionist>?> GetReceptionistsAsync();
    Task<IEnumerable<Administrator>?> GetAdministratorsAsync();
}
