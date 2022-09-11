namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IEmployeeDataProvider
{
    Task<Employee?> GetEmployeeByIdAsync(Guid id);
    Task<Receptionist?> GetReceptionistByIdAsync(Guid id);
    Task<Administrator?> GetAdministratorByIdAsync(Guid id);
    Task<IEnumerable<Employee>?> GetAllEmployeesAsync();
    Task<IEnumerable<Receptionist>?> GetReceptionistsAsync();
    Task<IEnumerable<Administrator>?> GetAdministratorsAsync();
    Task<IEnumerable<Receptionist>?> GetActiveReceptionistsAsync();
    Task<IEnumerable<Employee>?> GetActiveEmployeesAsync();
    Task<IEnumerable<Administrator>?> GetActiveAdministratorsAsync();
    Task<IEnumerable<Receptionist>?> SearchReceptionistsAsync(ReceptionistSearchOptions searchParams);
}
