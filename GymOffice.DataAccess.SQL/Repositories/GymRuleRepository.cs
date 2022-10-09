namespace GymOffice.DataAccess.SQL.Repositories;
public class GymRuleRepository : IGymRuleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public GymRuleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddRuleAsync(GymRule rule)
    {        
        await _dbContext.Rules.AddAsync(rule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddRuleSectionAsync(RuleSection section)
    {
        await _dbContext.RuleSections.AddAsync(section);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<GymRule>?> GetActiveRulesBySectionIdAsync(Guid sectionId)
    {
        return await _dbContext.Rules
            .Where(r => r.Section.Id == sectionId && r.IsActive == true)
            .Include(r => r.CreatedBy)
            .Include(r => r.ModifiedBy)
            .ToListAsync();
    }

    public async Task<ICollection<RuleSection>?> GetActiveRuleSectionsAsync()
    {
        return await _dbContext.RuleSections
            .Where(s => s.IsActive)
            .Include(s => s.CreatedBy)
            .Include(s => s.ModifiedBy)
            .ToListAsync();
    }

    public async Task<GymRule?> GetGymRuleByIdAsync(Guid ruleId)
    {
        return await _dbContext.Rules.SingleOrDefaultAsync(r => r.Id == ruleId);
    }

    public async Task<ICollection<GymRule>?> GetRulesBySectionIdAsync(Guid sectionId)
    {
        return await _dbContext.Rules
            .Where(r => r.Section.Id == sectionId)
            .Include(r => r.CreatedBy)
            .Include(r => r.ModifiedBy)
            .ToListAsync();
    }

    public async Task<RuleSection?> GetRuleSectionByIdAsync(Guid sectionId)
    {
        return await _dbContext.RuleSections.SingleOrDefaultAsync(s => s.Id == sectionId);
    }

    public async Task<ICollection<RuleSection>?> GetRuleSectionsAsync()
    {
        return await _dbContext.RuleSections
            .Include(s => s.CreatedBy)
            .Include(s => s.ModifiedBy)
            .ToListAsync();
    }

    public async Task UpdateRuleAsync(GymRule rule)
    {
        GymRule? entity = await GetGymRuleByIdAsync(rule.Id);
        if (entity == null)
            return;

        _dbContext.Rules.Update(rule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRuleSectionAsync(RuleSection section)
    {
        RuleSection? entity = await GetRuleSectionByIdAsync(section.Id);
        if (entity == null)
            return;

        _dbContext.RuleSections.Update(section);
        await _dbContext.SaveChangesAsync();
    }
}
