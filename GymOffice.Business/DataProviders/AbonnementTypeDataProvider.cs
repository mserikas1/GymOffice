namespace GymOffice.Business.DataProviders;
public class AbonnementTypeDataProvider : IAbonnementTypeDataProvider
{
    private readonly IAbonnementTypeRepository _abonnementTypeRepository;

    public AbonnementTypeDataProvider(IAbonnementTypeRepository abonnementTypeRepository)
    {
        _abonnementTypeRepository = abonnementTypeRepository;
    }

    public async Task<ICollection<AbonnementType>?> GetAllAbonnementTypesAsync()
    {
        return await _abonnementTypeRepository.GetAllTypesAsync();
    }
}
