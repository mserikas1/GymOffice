namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Edit;
public interface IEditGymRuleCommand
{
    Task ExecuteAsync(GymRule rule);
}
