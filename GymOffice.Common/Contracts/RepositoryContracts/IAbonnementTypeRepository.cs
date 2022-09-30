namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IAbonnementTypeRepository
{
    Task<ICollection<AbonnementType>?> GetAllTypesAsync();
}
