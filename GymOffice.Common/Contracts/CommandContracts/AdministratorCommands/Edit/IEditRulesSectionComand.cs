namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Edit;
public interface IEditRulesSectionCommand
{
    Task ExecuteAsync(RuleSection section);
}
