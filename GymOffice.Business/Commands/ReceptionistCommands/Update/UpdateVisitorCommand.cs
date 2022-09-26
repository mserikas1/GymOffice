using GymOffice.Business.Common.Exceptions;
using GymOffice.Common.Contracts.CommandContracts.ReceptionistCommands.Update;

namespace GymOffice.Business.Commands.ReceptionistCommands.Update;
public class UpdateVisitorCommand : IUpdateVisitorCommand
{
    private readonly IVisitorRepository _visitorRepository;

    public UpdateVisitorCommand(IVisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

    public async Task ExecuteAsync(Visitor visitor)
    {
        if (visitor == null)
        {
            throw new ArgumentNullException(nameof(visitor));
        }
        if (await _visitorRepository.GetVisitorByIdAsync(visitor.Id) == null)
        {
            throw new NotFoundException(nameof(Visitor), visitor.Id);
        }
        await _visitorRepository.UpdateVisitorAsync(visitor);
    }
}
