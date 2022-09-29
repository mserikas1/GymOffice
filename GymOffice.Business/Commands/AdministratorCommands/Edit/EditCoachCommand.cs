namespace GymOffice.Business.Commands.AdministratorCommands.Edit;
public class EditCoachCommand : IEditCoachCommand
{
    private readonly ICoachRepository _coachRepository;

    public EditCoachCommand(ICoachRepository coachRepository)
    {
        _coachRepository = coachRepository;
    }

    public async Task ExecuteAsync(Coach coach)
    {
        if (coach == null)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(coach.FirstName) ||
            string.IsNullOrWhiteSpace(coach.LastName) ||
            string.IsNullOrWhiteSpace(coach.Email) ||
            string.IsNullOrWhiteSpace(coach.PhoneNumber) ||
            string.IsNullOrWhiteSpace(coach.PhotoUrl) ||
            coach.CreatedBy == null ||
            coach.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        Coach? entity = await _coachRepository.GetCoachByIdAsync(coach.Id);
        if (entity == null || entity.Id != coach.Id)
        {
            throw new NotFoundException(nameof(Coach), coach.Id);
        }

        await _coachRepository.UpdateCoachAsync(coach);
    }
}
