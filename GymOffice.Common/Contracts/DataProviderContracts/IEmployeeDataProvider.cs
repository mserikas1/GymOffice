namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IEmployeeDataProvider
{
    Task<Admin?> GetAdministratorByIdAsync(Guid id);
    Task<ICollection<Admin>?> GetAdministratorsAsync();
<<<<<<< HEAD
    Task<ICollection<Receptionist>?> GetReceptionistsAsync();
    ICollection<Admin>? GetAdministrators();
    Task<ICollection<Receptionist>?> SearchReceptionistsAsync(ReceptionistSearchOptions options);
=======
    ICollection<Admin>? GetAdministrators();
>>>>>>> oleg-feature-receptionist-pages
}
