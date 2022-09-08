namespace GymOffice.Business.Queries;
public class GetAllEmployeesQuery : IGetAllEmployeesQuery
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesQuery(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Employee>?> Execute()
    {
        return await _employeeRepository.GetEmployeesAsync();
    }
}
