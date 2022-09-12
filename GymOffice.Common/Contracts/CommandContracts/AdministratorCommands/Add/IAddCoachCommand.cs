namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddCoachCommand
{
    Task<Guid> ExecuteAsync(Coach coach);
}
