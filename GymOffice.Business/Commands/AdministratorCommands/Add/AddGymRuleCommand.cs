using GymOffice.Common.DTOs;

namespace GymOffice.Business.Commands.AdministratorCommands.Add;
public class AddGymRuleCommand : IAddGymRuleCommand
{
    private readonly IGymRuleRepository _ruleRepository;

    public AddGymRuleCommand(IGymRuleRepository ruleRepository)
    {
        _ruleRepository = ruleRepository;
    }

    public async Task ExecuteAsync(GymRule rule)
    {
        if (rule == null)
        {
            throw new ArgumentNullException(nameof(rule));
        }
        if (string.IsNullOrWhiteSpace(rule.Description) ||
            rule.Section == null ||
            rule.CreatedBy == null ||
            rule.ModifiedBy == null)
        {
            throw new RequiredPropertiesNotFilledException();
        }
        if (await _ruleRepository.GetGymRuleByIdAsync(rule.Id) != null)
        {
            throw new SameEntityExistsException(nameof(GymRule), rule.Id);
        }

        if (rule.IsActive == false)
            rule.IsActive = true;

        await _ruleRepository.AddRuleAsync(rule);
    }
}
