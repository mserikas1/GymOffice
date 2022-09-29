namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddCoachCommand
{
    Task ExecuteAsync(Coach coach);
}
