﻿namespace GymOffice.Business.DataProviders;
public class AbonnementTypeDataProvider : IAbonnementTypeDataProvider
{
    private readonly IAbonnementTypeRepository _abonnementTypeRepository;

    public AbonnementTypeDataProvider(IAbonnementTypeRepository abonnementTypeRepository)
    {
        _abonnementTypeRepository = abonnementTypeRepository;
    }

    public async Task<ICollection<AbonnementType>?> GetActiveTypesAsync()
    {
        return await _abonnementTypeRepository.GetActiveTypesAsync();
    }

    public ICollection<AbonnementType>? GetActiveAbonnementTypes()
    {
        return _abonnementTypeRepository.GetActiveAbonnementTypes();
    }
    public async Task<ICollection<AbonnementType>?> GetAllAbonnementTypesAsync()
    {
        return await _abonnementTypeRepository.GetAllTypesAsync();
    }

    public async Task<AbonnementType?> GetByIdAsync(Guid id)
    {
        return await _abonnementTypeRepository.GetByIdAsync(id);
    }
}
