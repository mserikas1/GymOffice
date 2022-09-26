namespace GymOffice.Business.DataProviders;
public class CoachDataProvider : ICoachDataProvider
{
    private readonly ICoachRepository _coachRepository;

    public CoachDataProvider(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task<ICollection<Coach>?> GetAllCoachesAsync()
    {
        return await _coachRepository.GetAllCoachesAsync();
    }
}
