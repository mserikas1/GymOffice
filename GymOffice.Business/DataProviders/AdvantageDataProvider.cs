using GymOffice.Common.SearchParams;

namespace GymOffice.Business.DataProviders;

public class AdvantageDataProvider : IAdvantageDataProvider
{
    private readonly IAdvantageRepository _advantageRepository;

    public AdvantageDataProvider(IAdvantageRepository advantageRepository)
    {
        _advantageRepository = advantageRepository;
    }

    public async Task<Advantage?> GetAdvantageByIdAsync(Guid id)
    {
        Advantage? entity = await _advantageRepository.GetAdvantageByIdAsync(id);

        if (entity == null || entity.Id != id)
        {
            throw new NotFoundException(nameof(Advantage), id);
        }

        return entity;
    }

    public async Task<ICollection<Advantage>?> GetAdvantagesAsync()
    {
        return await _advantageRepository.GetAdvantagesAsync();
    }

    public async Task<ICollection<Advantage>?> SearchAdvantagesAsync(AdvantageSearchOptions options)
    {
        if (options == null)
        {
            return null;
        }
        if (options.IsNullOrEmpty())
        {
            return await _advantageRepository.GetAdvantagesAsync();
        }
        return await _advantageRepository.SearchAdvantagesAsync(options);
    }
}
