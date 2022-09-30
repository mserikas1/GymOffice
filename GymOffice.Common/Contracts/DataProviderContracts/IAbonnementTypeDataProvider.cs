namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IAbonnementTypeDataProvider
{
    Task<ICollection<AbonnementType>?> GetAllAbonnementTypesAsync();
}
