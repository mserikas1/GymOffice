using GymOffice.Business.Common.Exceptions;

namespace GymOffice.Business.Queries;
public class GetCoachByIdQuery : IGetCoachByIdQuery
{
    private readonly ICoachRepository _coachRepository;

    public GetCoachByIdQuery(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task<Coach?> Execute(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id), "Incorrect coach Id");
        }

        Coach? coach = await _coachRepository.GetCoachByIdAsync(id);

        if (coach == null)
        {
            throw new NotFoundException(nameof(Coach), id);
        }

        return coach;
    }
}
