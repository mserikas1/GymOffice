namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddGymRuleCommand
{
    Task ExecuteAsync(GymRule rule);
}
