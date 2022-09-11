namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IAbonnementTypeDataProvider
{
    Task<IEnumerable<AbonnementType>?> GetAllAbonnementTypesAsync();
    Task<AbonnementType?> GetAbonnementTypeByIdAsync(Guid id);
    Task<AbonnementType?> GetAbonnementTypeByNameAsync(string name);
}
