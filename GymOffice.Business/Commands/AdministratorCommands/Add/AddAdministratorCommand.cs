namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddAdministratorCommand : IAddAdministratorCommand
{
    private readonly IEmployeeRepository _employeeRepository;

    public AddAdministratorCommand(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task ExecuteAsync(Admin administrator)
    {
        if (administrator == null)
        {
            throw new ArgumentNullException(nameof(administrator));
        }
        if (administrator.FirstName == null ||
            administrator.LastName == null ||
            administrator.Email == null ||
            administrator.PhoneNumber == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        if (await _employeeRepository.GetEmployeeByIdAsync(administrator.Id) != null)
        {
            throw new SameEntityExistsException(nameof(Admin), administrator.Id);
        }
        await _employeeRepository.AddAdministratorAsync(administrator);
        await _employeeRepository.AddEmployeeAsync(administrator);
    }
}
