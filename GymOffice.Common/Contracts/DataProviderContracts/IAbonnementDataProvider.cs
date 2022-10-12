namespace GymOffice.Common.Contracts.DataProviderContracts
{
    public interface IAbonnementDataProvider
    {
        ICollection<Abonnement>? GetAbonnementsById(Guid id);
        Task<ICollection<Abonnement>?> GetAllAsync();
        ICollection<Abonnement>? GetAll();
        Task<ICollection<Abonnement>?> GetActiveAsync();
        Task<ICollection<Abonnement>?> SearchAbonnementsAsync(AbonnementSearchOptions options);
    }
}
