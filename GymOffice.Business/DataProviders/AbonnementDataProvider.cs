using GymOffice.Common.Contracts.RepositoryContracts;

namespace GymOffice.Business.DataProviders
{
    public class AbonnementDataProvider : IAbonnementDataProvider
    {
        private readonly IAbonnementRepository _abonnementRepository;
        public AbonnementDataProvider(IAbonnementRepository abonnementRepository)
        {
            _abonnementRepository = abonnementRepository;
        }
        public ICollection<Abonnement>? GetAbonnementsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Abonnement>?> GetActiveAsync()
        {
            return await _abonnementRepository.GetActiveAsync();
        }

        public async Task<ICollection<Abonnement>?> GetAllAsync()
        {
            return await _abonnementRepository.GetAllAsync();
        }

        public async Task<ICollection<Abonnement>?> SearchAbonnementsAsync(AbonnementSearchOptions options)
        {
            if (options == null)
            {
                return null;
            }
            if (options.IsNullOrEmpty())
            {
                return await _abonnementRepository.GetAllAsync();
            }
            return await _abonnementRepository.SearchAbonnementsAsync(options);
        }
    }
}
