namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IEmployeeDataProvider
{
    Task<Admin?> GetAdministratorByIdAsync(Guid id);
    Task<ICollection<Admin>?> GetAdministratorsAsync();
    ICollection<Admin>? GetAdministrators();
}
