namespace GymOffice.Business.Queries;
public class GetAllAdministratorsQuery : IGetAllAdministratorsQuery
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllAdministratorsQuery(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Administrator>?> Execute()
    {
        return await _employeeRepository.GetAdministratorsAsync();
    }
}
