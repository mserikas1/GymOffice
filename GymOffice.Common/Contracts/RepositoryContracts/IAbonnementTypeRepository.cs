namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IAbonnementTypeRepository
{
    Task<IEnumerable<AbonnementType>?> GetAllTypesAsync();
    Task<AbonnementType?> GetByIdAsync(Guid id);
    Task<AbonnementType?> GetByNameAsync(string name);
}
