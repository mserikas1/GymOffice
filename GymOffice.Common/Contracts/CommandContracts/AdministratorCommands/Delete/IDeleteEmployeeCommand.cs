namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Delete;
public interface IDeleteEmployeeCommand
{
    Task<Employee> ExecuteAsync(Guid employeeId);
}
