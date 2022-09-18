namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddReceptionistCommand : IAddReceptionistCommand
{
    private readonly IEmployeeRepository _employeeRepository;

    public AddReceptionistCommand(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task ExecuteAsync(Receptionist receptionist)
    {
        if (receptionist == null)
        {
            throw new ArgumentNullException(nameof(receptionist));
        }
        if (receptionist.FirstName == null ||
            receptionist.LastName == null ||
            receptionist.Email == null ||
            receptionist.PhoneNumber == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        if (await _employeeRepository.GetReceptionistByIdAsync(receptionist.Id) != null)
        {
            throw new SameEntityExistsException(nameof(Receptionist), receptionist.Id);
        }

        await _employeeRepository.AddReceptionistAsync(receptionist);
    }
}