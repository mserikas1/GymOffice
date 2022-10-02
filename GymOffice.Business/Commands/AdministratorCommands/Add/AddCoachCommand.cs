namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddCoachCommand : IAddCoachCommand
{
    private readonly ICoachRepository _coachRepository;

    public AddCoachCommand(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task ExecuteAsync(Coach coach)
    {
        if (coach == null)
        {
            throw new ArgumentNullException(nameof(coach));
        }
        if (coach.FirstName == null ||
            coach.LastName == null ||
            coach.Email == null ||
            coach.PhoneNumber == null ||
            coach.PhotoUrl == null ||
            coach.CreatedBy == null ||
            coach.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        if (await _coachRepository.GetCoachByIdAsync(coach.Id) != null)
        {
            throw new SameEntityExistsException(nameof(Coach), coach.Id);
        }

        await _coachRepository.AddCoachAsync(coach);
    }
}
