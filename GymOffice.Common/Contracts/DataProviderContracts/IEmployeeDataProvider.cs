namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IEmployeeDataProvider
{
    Task<Admin?> GetAdministratorByIdAsync(Guid id);
    Task<Receptionist?> GetReceptionistByIdAsync(Guid id);
    Task<ICollection<Admin>?> GetAdministratorsAsync();
    Task<ICollection<Receptionist>?> GetReceptionistsAsync();
    ICollection<Admin>? GetAdministrators();
    Task<ICollection<Receptionist>?> SearchReceptionistsAsync(ReceptionistSearchOptions options);
}
