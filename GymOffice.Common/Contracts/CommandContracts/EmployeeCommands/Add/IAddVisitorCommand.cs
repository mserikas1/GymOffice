namespace GymOffice.Common.Contracts.CommandContracts.EmployeeCommands.Add;
public interface IAddVisitorCommand
{
    Task ExecuteAsync(Visitor visitor, bool only_check = false);
}
