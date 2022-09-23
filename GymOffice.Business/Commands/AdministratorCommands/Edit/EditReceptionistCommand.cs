namespace GymOffice.Business.Commands.AdministratorCommands.Edit;
public class EditReceptionistCommand : IEditReceptionistCommand
{
    private readonly IEmployeeRepository _employeeRepository;

    public EditReceptionistCommand(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task ExecuteAsync(Receptionist receptionist)
    {
        if (receptionist == null)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(receptionist.FirstName) ||
            string.IsNullOrWhiteSpace(receptionist.LastName) ||
            string.IsNullOrWhiteSpace(receptionist.Email) ||
            string.IsNullOrWhiteSpace(receptionist.PhoneNumber) ||
            receptionist.CreatedBy == null ||
            receptionist.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        Receptionist? entity = await _employeeRepository.GetReceptionistByIdAsync(receptionist.Id);
        if (entity == null || entity.Id != receptionist.Id)
        {
            throw new NotFoundException(nameof(Receptionist), receptionist.Id);
        }

        await _employeeRepository.UpdateReceptionistAsync(receptionist);
    }
}
