using GymOffice.Common.Contracts.RepositoryContracts;

namespace GymOffice.Business.DataProviders;
public class CoachDataProvider : ICoachDataProvider
{
    private readonly ICoachRepository _coachRepository;

    public CoachDataProvider(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task<ICollection<Coach>?> GetCoachesAtWorkAsync()
    {
        return await _coachRepository.GetCoachesAtWorkAsync();
    }

    public async Task<ICollection<Coach>?> GetActiveCoachesNotAtWorkAsync()
    {
        return await _coachRepository.GetActiveCoachesNotAtWorkAsync();
    }
    public async Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync()
    {
        return await _coachRepository.GetCoachesNotAtWorkAsync();
    }

    public async Task<ICollection<Coach>?> GetAllCoachesAsync()
    {
        return await _coachRepository.GetAllCoachesAsync();
    }
    public async Task<ICollection<Coach>?> GetActiveCoachesAsync()
    {
        return await _coachRepository.GetActiveCoachesAsync();
    }

    public async Task<Coach?> GetCoachByIdAsync(Guid id)
    {
        Coach? entity = await _coachRepository.GetCoachByIdAsync(id);

        if (entity == null || entity.Id != id)
        {
            throw new NotFoundException(nameof(Coach), id);
        }

        return entity;
    }

    public async Task<ICollection<Coach>?> SearchCoachsAsync(CoachSearchOptions options)
    {
        if (options == null)
        {
            return null;
        }
        if (options.IsNullOrEmpty())
        {
            return await _coachRepository.GetAllCoachesAsync();
        }
        return await _coachRepository.SearchCoachesAsync(options);
    }
    public ICollection<Coach>? GetActiveCoaches()
    {
        return _coachRepository.GetActiveCoaches();
    }
}
