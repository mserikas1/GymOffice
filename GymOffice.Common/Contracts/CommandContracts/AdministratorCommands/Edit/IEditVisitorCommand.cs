namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Edit;
public interface IEditVisitorCommand
{
    Task ExecuteAsync(Visitor visitor);
}
