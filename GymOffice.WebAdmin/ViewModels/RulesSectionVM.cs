namespace GymOffice.WebAdmin.ViewModels;
public class RulesSectionVM
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name length must be between 2 and 50 characters")]
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Admin CreatedBy { get; set; } = null!;
    public Admin ModifiedBy { get; set; } = null!;
    public ICollection<GymRule> GymRules { get; set; } = new List<GymRule>();
}
