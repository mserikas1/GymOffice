namespace GymOffice.Business.Commands.AdministratorCommands.Edit;
public class EditRulesSectionCommand : IEditRulesSectionCommand
{
    private readonly IGymRuleRepository _ruleRepository;

    public EditRulesSectionCommand(IGymRuleRepository ruleRepository)
    {
        _ruleRepository = ruleRepository;
    }

    public async Task ExecuteAsync(RuleSection section)
    {
        if (section == null)
        {
            return;
        }
        if (string.IsNullOrWhiteSpace(section.Name) ||
            section.CreatedBy == null ||
            section.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }

        RuleSection? entity = await _ruleRepository.GetRuleSectionByIdAsync(section.Id);
        if (entity == null || entity.Id != section.Id)
        {
            throw new NotFoundException(nameof(RuleSection), section.Id);
        }

        await _ruleRepository.UpdateRuleSectionAsync(section);
    }
}
