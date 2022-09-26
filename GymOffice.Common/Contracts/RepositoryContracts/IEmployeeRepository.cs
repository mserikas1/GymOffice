namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IEmployeeRepository
{
<<<<<<< HEAD
=======
    Task AddAdministratorAsync(Admin admin);
    Task AddEmployeeAsync(Employee employee);
>>>>>>> oleg-feature-receptionist-pages
    Task<ICollection<Admin>?> GetAdministratorsAsync();
    ICollection<Admin>? GetAdministrators();
    Task<Admin?> GetAdministratorByIdAsync(Guid id);
    Task<Receptionist?> GetReceptionistByIdAsync(Guid id);
    Task AddReceptionistAsync(Receptionist receptionist);
<<<<<<< HEAD
    Task<ICollection<Receptionist>?> GetReceptionistsAsync();
    Task UpdateReceptionistAsync(Receptionist receptionist);
    Task<ICollection<Receptionist>?> SearchReceptionistsAsync(ReceptionistSearchOptions options);
=======
    Task<Employee?> GetEmployeeByIdAsync(Guid id);
>>>>>>> oleg-feature-receptionist-pages
}
