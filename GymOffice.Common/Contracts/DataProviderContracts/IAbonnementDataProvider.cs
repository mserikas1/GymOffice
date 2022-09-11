using GymOffice.Common.Utilities.Enums;

namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IAbonnementDataProvider
{
    Task<IEnumerable<Abonnement>?> GetAllAbonnementsAsync();
    Task<IEnumerable<Abonnement>?> GetAbonnementsByDurationAsync(AbonnementDuration duration);
    Task<IEnumerable<Abonnement>?> GetAbonnementsByTypeAsync(AbonnementType type);
    Task<IEnumerable<Abonnement>?> GetAbonnementsByCustomerIdAsync(Guid customerId);
    Task<Abonnement?> GetAbonnementByIdAsync(Guid id);
}
