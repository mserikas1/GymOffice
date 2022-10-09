namespace GymOffice.Common.Contracts.CommandContracts.AdministratorCommands.Add;
public interface IAddRulesSectionCommand
{
    Task ExecuteAsync(RuleSection ruleSection);
}
