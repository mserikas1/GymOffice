namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IEmployeeRepository
{
    Task<ICollection<Admin>?> GetAdministratorsAsync();
    ICollection<Admin>? GetAdministrators();
    Task<Admin?> GetAdministratorByIdAsync(Guid id);
    Task<Receptionist?> GetReceptionistByIdAsync(Guid id);
    Task AddReceptionistAsync(Receptionist receptionist);
}
