namespace GymOffice.Common.Contracts.CommandContracts.ReceptionistCommands.Update;
public interface IUpdateCoachCommand
{
    Task ExecuteAsync(Coach coach);
}
