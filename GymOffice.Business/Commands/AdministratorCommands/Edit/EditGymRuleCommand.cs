namespace GymOffice.Business.Commands.AdministratorCommands.Edit;
public class EditGymRuleCommand : IEditGymRuleCommand
{
    private readonly IGymRuleRepository _ruleRepository;

    public EditGymRuleCommand(IGymRuleRepository ruleRepository)
    {
        _ruleRepository = ruleRepository;
    }

    public async Task ExecuteAsync(GymRule rule)
    {
        if (rule == null)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(rule.Description) ||
            rule.Section == null ||
            rule.CreatedBy == null ||
            rule.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }

        GymRule? entity = await _ruleRepository.GetGymRuleByIdAsync(rule.Id);
        if (entity == null || entity.Id != rule.Id)
        {
            throw new NotFoundException(nameof(GymRule), rule.Id);
        }

        await _ruleRepository.UpdateRuleAsync(rule);
    }
}
