namespace GymOffice.WebAdmin.ViewModels;
public class GymRuleVM
{
    public Guid Id { get; set; }

    [Required]
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }
    public RuleSection Section { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Admin CreatedBy { get; set; } = null!;
    public Admin ModifiedBy { get; set; } = null!;
}
