namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IGymRulesDataProvider
{
    Task<ICollection<RuleSection>?> GetRuleSectionsAsync();
    Task<ICollection<RuleSection>?> GetActiveRuleSectionsAsync();
    Task<ICollection<GymRule>?> GetRulesBySectionIdAsync(Guid sectionId);
    Task<ICollection<GymRule>?> GetActiveRulesBySectionIdAsync(Guid sectionId);
    Task<GymRule?> GetGymRuleAsync(Guid ruleId);
    Task<RuleSection?> GetRuleSectionAsync(Guid sectionId);
}
