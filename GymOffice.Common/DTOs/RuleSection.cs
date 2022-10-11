namespace GymOffice.Common.DTOs;
public class RuleSection
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Admin CreatedBy { get; set; } = null!;
    public Admin ModifiedBy { get; set; } = null!;
    public ICollection<GymRule> GymRules { get; set; } = new List<GymRule>();
}
