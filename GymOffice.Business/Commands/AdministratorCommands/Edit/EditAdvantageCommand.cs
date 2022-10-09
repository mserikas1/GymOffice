namespace GymOffice.Business.Commands.AdministratorCommands.Edit;
public class EditAdvantageCommand : IEditAdvantageCommand
{
    private readonly IAdvantageRepository _advantageRepository;

    public EditAdvantageCommand(IAdvantageRepository advantageRepository)
    {
        _advantageRepository = advantageRepository;
    }

    public async Task ExecuteAsync(Advantage advantage)
    {
        if (advantage == null)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(advantage.Title) ||
            string.IsNullOrWhiteSpace(advantage.Description) ||
            string.IsNullOrWhiteSpace(advantage.PhotoUrl) ||
            advantage.CreatedBy == null ||
            advantage.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        Advantage? entity = await _advantageRepository.GetAdvantageByIdAsync(advantage.Id);
        if (entity == null || entity.Id != advantage.Id)
        {
            throw new NotFoundException(nameof(Advantage), advantage.Id);
        }

        await _advantageRepository.UpdateAdvantageAsync(advantage);
    }
}
