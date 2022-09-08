namespace GymOffice.Business.Queries;
public class GetAllCoachesQuery : IGetAllCoachesQuery
{
    private readonly ICoachRepository _coachRepository;

    public GetAllCoachesQuery(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task<IEnumerable<Coach>?> Execute()
    {        
        return await _coachRepository.GetAllCoachesAsync();
    }
}
