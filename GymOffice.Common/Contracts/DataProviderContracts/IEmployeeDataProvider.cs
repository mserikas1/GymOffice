namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IEmployeeDataProvider
{
    Task<Admin?> GetAdministratorByIdAsync(Guid id);
    Task<ICollection<Admin>?> GetAdministratorsAsync();
    Task<ICollection<Receptionist>?> GetReceptionistsAsync();
    ICollection<Admin>? GetAdministrators();
}
