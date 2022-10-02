namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Edit;
public interface IEditCoachCommand
{
    Task ExecuteAsync(Coach coach);
}
