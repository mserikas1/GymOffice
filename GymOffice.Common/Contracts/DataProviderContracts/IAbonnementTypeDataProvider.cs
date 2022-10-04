namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IAbonnementTypeDataProvider
{
    Task<ICollection<AbonnementType>?> GetAllAbonnementTypesAsync();
    Task<ICollection<AbonnementType>?> GetActiveTypesAsync();
    Task<AbonnementType?> GetByIdAsync(Guid id);
}
