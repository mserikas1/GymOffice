namespace GymOffice.Business.Commands.EmployeeCommands;
public class EditVisitorCommand : IEditVisitorCommand
{
    private readonly IVisitorRepository _visitorRepository;

    public EditVisitorCommand(IVisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

    public async Task ExecuteAsync(Visitor visitor)
    {
        if (visitor == null)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(visitor.FirstName) ||
            string.IsNullOrWhiteSpace(visitor.LastName) ||
            string.IsNullOrWhiteSpace(visitor.PhoneNumber) ||
            visitor.VisitorCard == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        Visitor? entity = await _visitorRepository.GetVisitorByIdAsync(visitor.Id);
        if (entity == null || entity.Id != visitor.Id)
        {
            throw new NotFoundException(nameof(Visitor), visitor.Id);
        }

        await _visitorRepository.UpdateVisitorAsync(visitor);
    }
}
