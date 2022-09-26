using GymOffice.Business.Common.Exceptions;
using GymOffice.Common.Contracts.CommandContracts.ReceptionistCommands.Update;

namespace GymOffice.Business.Commands.ReceptionistCommands.Update;
public class UpdateCoachCommand : IUpdateCoachCommand
{
    private readonly ICoachRepository _coachRepository;

    public UpdateCoachCommand(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task ExecuteAsync(Coach coach)
    {
        if (coach == null)
        {
            throw new ArgumentNullException(nameof(coach));
        }
        if (await _coachRepository.GetCoachByIdAsync(coach.Id) == null)
        {
            throw new NotFoundException(nameof(Coach), coach.Id);
        }
        await _coachRepository.UpdateCoachAsync(coach);
    }
}
