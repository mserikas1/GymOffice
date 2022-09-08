namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IAbonnementRepository
{
    Task<Abonnement?> GetByIdAsync(Guid id);
    Task<IEnumerable<Abonnement>?> GetAllAsync();

}
