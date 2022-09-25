using GymOffice.Business.Common.Exceptions;
using GymOffice.Common.Contracts.CommandContracts.EmployeeCommands.Add;

namespace GymOffice.Business.Commands.EmployeeCommands.Add;
public class AddVisitorCommand : IAddVisitorCommand
{
    private readonly IVisitorRepository _visitorRepository;

    public AddVisitorCommand(IVisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

    public async Task ExecuteAsync(Visitor visitor)
    {
        if (visitor == null)
        {
            throw new ArgumentNullException(nameof(visitor));
        }
        if (visitor.FirstName == null ||
            visitor.LastName == null ||
            visitor.PhoneNumber == null )
        {
            throw new RequiredPropertiesNotFilledException();
        }
        if (await _visitorRepository.GetVisitorByIdAsync(visitor.Id) != null)
        {
            throw new SameEntityExistsException(nameof(Visitor), visitor.Id);
        }
        await _visitorRepository.AddVisitorAsync(visitor);
    }
}
