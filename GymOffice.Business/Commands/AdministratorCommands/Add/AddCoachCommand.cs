using GymOffice.Business.Common.Exceptions;
using GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;

namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddCoachCommand : IAddCoachCommand
{
    private readonly ICoachRepository _coachRepository;

    public AddCoachCommand(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task<Guid> ExecuteAsync(Coach coach)
    {
        if (coach == null)
        {
            throw new ArgumentNullException(nameof(coach));
        }
        if (coach.FirstName == null ||
            coach.LastName == null ||
            coach.Email == null ||
            coach.PhoneNumber == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        if (await _coachRepository.GetCoachByIdAsync(coach.Id) != null)
        {
            throw new SameEntityExistsException(nameof(Coach), coach.Id);
        }

        return await _coachRepository.AddCoachAsync(coach);
    }
}
