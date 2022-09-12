namespace GymOffice.Common.Contracts.CommandContracts.EmployeeCommands.Add;
public interface IAddCustomerCommand
{
    Task<Guid> ExecuteAsync(Customer customer);
}
