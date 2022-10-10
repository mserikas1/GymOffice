using GymOffice.Common.Contracts.RepositoryContracts;

namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddAdvantageCommand : IAddAdvantageCommand
{
    private readonly IAdvantageRepository _advantageRepository;

    public AddAdvantageCommand(IAdvantageRepository advantageRepository)
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
        if (await _advantageRepository.GetAdvantageByIdAsync(advantage.Id) != null)
        {
            throw new SameEntityExistsException(nameof(Advantage), advantage.Id);
        }

        await _advantageRepository.AddAdvantageAsync(advantage);
    }
}