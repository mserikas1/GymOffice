namespace GymOffice.Common.Contracts.CommandContracts.ReceptionistCommands.Update;
public interface IUpdateVisitorCommand
{
    Task ExecuteAsync(Visitor visitor);
}
