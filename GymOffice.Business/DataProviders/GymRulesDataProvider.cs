namespace GymOffice.Business.DataProviders;
public class GymRulesDataProvider : IGymRulesDataProvider
{
    private readonly IGymRuleRepository _ruleRepository;

    public GymRulesDataProvider(IGymRuleRepository ruleRepository)
    {
        _ruleRepository = ruleRepository;
    }

    public async Task<ICollection<GymRule>?> GetActiveRulesBySectionIdAsync(Guid sectionId)
    {
        return await _ruleRepository.GetActiveRulesBySectionIdAsync(sectionId);
    }

    public async Task<ICollection<RuleSection>?> GetActiveRuleSectionsAsync()
    {
        return await _ruleRepository.GetActiveRuleSectionsAsync();
    }

    public async Task<GymRule?> GetGymRuleAsync(Guid ruleId)
    {
        return await _ruleRepository.GetGymRuleByIdAsync(ruleId);
    }

    public async Task<ICollection<GymRule>?> GetRulesBySectionIdAsync(Guid sectionId)
    {
        return await _ruleRepository.GetRulesBySectionIdAsync(sectionId);
    }

    public async Task<RuleSection?> GetRuleSectionAsync(Guid sectionId)
    {
        return await _ruleRepository.GetRuleSectionByIdAsync(sectionId);
    }

    public async Task<ICollection<RuleSection>?> GetRuleSectionsAsync()
    {
        return await _ruleRepository.GetRuleSectionsAsync();
    }
}
