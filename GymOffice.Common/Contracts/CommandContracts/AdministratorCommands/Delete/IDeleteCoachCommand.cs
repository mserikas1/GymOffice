namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Delete;
public interface IDeleteCoachCommand
{
    Task<Coach> ExecuteAsync(Guid coachId);
}
