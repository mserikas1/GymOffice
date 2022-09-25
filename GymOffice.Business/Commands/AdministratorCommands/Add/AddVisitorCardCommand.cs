using GymOffice.Business.Common.Exceptions;
using GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;

namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddVisitorCardCommand : IAddVisitorCardCommand
{
    private readonly IVisitorRepository _visitorRepository;

    public AddVisitorCardCommand(IVisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

    public async Task ExecuteAsync(VisitorCard visitorCard)
    {
        if (visitorCard == null)
        {
            throw new ArgumentNullException(nameof(visitorCard));
        }
        if (visitorCard.Visitor == null ||
            visitorCard.BarCode == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        if (await _visitorRepository.GetVisitorCardByIdAsync(visitorCard.Id) != null)
        {
            throw new SameEntityExistsException(nameof(VisitorCard), visitorCard.Id);
        }
        await _visitorRepository.AddVisitorCardAsync(visitorCard);
    }
}
