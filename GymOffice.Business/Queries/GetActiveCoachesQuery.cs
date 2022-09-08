namespace GymOffice.Business.Queries;
public class GetActiveCoachesQuery : IGetActiveCoachesQuery
{
    private readonly ICoachRepository _coachRepository;

    public GetActiveCoachesQuery(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task<IEnumerable<Coach>?> Execute()
    {
        return await _coachRepository.GetActiveCoachesAsync();
    }
}
