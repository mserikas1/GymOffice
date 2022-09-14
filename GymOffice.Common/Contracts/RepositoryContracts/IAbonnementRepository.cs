namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IAbonnementRepository
{
    Task<Abonnement?> GetByIdAsync(Guid id);
    Task<IEnumerable<Abonnement>?> GetAllAsync();
    Task<IEnumerable<Abonnement>?> GetByCustomerIdAsync(Guid customerId);
    Task<IEnumerable<Abonnement>?> GetByDurationAsync(AbonnementDuration duration);
    Task<IEnumerable<Abonnement>?> GetByTypeAsync(AbonnementType type);
    Task<Guid> AddAbonnementAsync(Abonnement abonnement);
    Task DeleteAsync(Abonnement abonnement);
    Task UpdateAsync(Abonnement abonnement);
}
