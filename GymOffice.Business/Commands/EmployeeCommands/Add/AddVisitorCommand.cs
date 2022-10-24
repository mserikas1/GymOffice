using GymOffice.Business.Common.Exceptions;
using GymOffice.Common.Contracts.CommandContracts.EmployeeCommands.Add;
using System.Linq.Expressions;

namespace GymOffice.Business.Commands.EmployeeCommands.Add;
public class AddVisitorCommand : IAddVisitorCommand
{
    private readonly IVisitorRepository _visitorRepository;

    public AddVisitorCommand(IVisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

    public async Task ExecuteAsync(Visitor visitor, bool only_check = false)
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
        if (visitor.Email != null && await _visitorRepository.GetVisitorByEmailAsync(visitor.Email) != null)
        {
            throw new SameEntityExistsException(nameof(Visitor), visitor.Email);
        }
        if (visitor.PhoneNumber != null && await _visitorRepository.GetVisitorByPhoneAsync(visitor.PhoneNumber) != null)
        {
            throw new SameEntityExistsException(nameof(Visitor), visitor.PhoneNumber);
        }
        if (!only_check) // we do not need to add Visitor to DB when we do it through adding visitor card
            await _visitorRepository.AddVisitorAsync(visitor);
    }
}
