namespace GymOffice.Common.Contracts.CommandContracts.EmployeeCommands.Add;
public interface IAddCustomerToGroupTrainingCommand
{
    Task ExecuteAsync(Guid trainingId, Guid customerId);
}
