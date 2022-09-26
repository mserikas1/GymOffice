using GymOffice.Business.Common.Exceptions;

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
        return await _coachRepository.GetActiveCoachesAsync();
    }
    public async Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync()
    {
        return await _coachRepository.GetCoachesNotAtWorkAsync();
    }

    public async Task<ICollection<Coach>?> GetAllCoachesAsync()
    {
        return await _coachRepository.GetAllCoachesAsync();
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
}
