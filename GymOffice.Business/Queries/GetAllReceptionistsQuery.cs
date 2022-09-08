namespace GymOffice.Business.Queries;
public class GetAllReceptionistsQuery : IGetAllReceptionistsQuery
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllReceptionistsQuery(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Receptionist>?> Exequte()
    {
        return await _employeeRepository.GetReceptionistsAsync();
    }
}
