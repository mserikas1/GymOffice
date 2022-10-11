namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IGymRuleRepository
{
    Task<ICollection<RuleSection>?> GetRuleSectionsAsync();
    Task<ICollection<RuleSection>?> GetActiveRuleSectionsAsync();
    Task<ICollection<GymRule>?> GetRulesBySectionIdAsync(Guid sectionId);
    Task<ICollection<GymRule>?> GetActiveRulesBySectionIdAsync(Guid sectionId);
    Task<GymRule?> GetGymRuleByIdAsync(Guid ruleId);
    Task<RuleSection?> GetRuleSectionByIdAsync(Guid sectionId);
    Task AddRuleAsync(GymRule rule);
    Task AddRuleSectionAsync(RuleSection section);
    Task UpdateRuleAsync(GymRule rule);
    Task UpdateRuleSectionAsync(RuleSection section);
}
