using GymOffice.Business.Commands.EmployeeCommands.Add;
using GymOffice.Common.Contracts.CommandContracts.EmployeeCommands.Add;

namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddVisitorCardCommand : IAddVisitorCardCommand
{
    private readonly IVisitorRepository _visitorRepository;
    private readonly IAddVisitorCommand _addVisitorCommand;

    public AddVisitorCardCommand(IVisitorRepository visitorRepository, IAddVisitorCommand addVisitorCommand)
    {
        _visitorRepository = visitorRepository;
        _addVisitorCommand = addVisitorCommand;
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
        try
        {
            await _addVisitorCommand.ExecuteAsync(visitorCard.Visitor, true); // only check prerequisites for visitor's adding
        }
        catch
        {
            throw; // if there is an exception during AddVisitorCommand check, the following does not executed, an error message should popup.
        }
        await _visitorRepository.AddVisitorCardAsync(visitorCard); // this will also add the visitor
    }
}
