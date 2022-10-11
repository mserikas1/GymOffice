using GymOffice.Common.DTOs;
using System.Data;

namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddRulesSectionCommand : IAddRulesSectionCommand
{
    private readonly IGymRuleRepository _ruleRepository;

    public AddRulesSectionCommand(IGymRuleRepository ruleRepository)
    {
        _ruleRepository = ruleRepository;
    }

    public async Task ExecuteAsync(RuleSection ruleSection)
    {
        if (ruleSection == null)
        {
            throw new ArgumentNullException(nameof(ruleSection));
        }
        if (string.IsNullOrWhiteSpace(ruleSection.Name) ||
            ruleSection.CreatedBy == null ||
            ruleSection.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        if (await _ruleRepository.GetRuleSectionByIdAsync(ruleSection.Id) != null)
        {
            throw new SameEntityExistsException(nameof(RuleSection), ruleSection.Id);
        }

        if (ruleSection.IsActive == false)
            ruleSection.IsActive = true;

        await _ruleRepository.AddRuleSectionAsync(ruleSection);
    }
}
