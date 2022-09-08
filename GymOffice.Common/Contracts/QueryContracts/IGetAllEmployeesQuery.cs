namespace GymOffice.Common.Contracts.QueryContracts;
public interface IGetAllEmployeesQuery
{
    Task<IEnumerable<Employee>?> Execute();
}
