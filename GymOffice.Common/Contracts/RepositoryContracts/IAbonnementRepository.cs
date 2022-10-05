namespace GymOffice.Common.Contracts.RepositoryContracts
{
    public interface IAbonnementRepository
    {
        ICollection<Abonnement>? GetAbonnementsById(Guid id);
        Task<ICollection<Abonnement>?> GetAllAsync();
        Task<ICollection<Abonnement>?> GetActiveAsync();
        Task<ICollection<Abonnement>?> SearchAbonnementsAsync(AbonnementSearchOptions options);
    }
}
