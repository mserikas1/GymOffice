namespace GymOffice.WebAdmin.ViewModels;
public class RulesSectionVM
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(250, MinimumLength = 2, ErrorMessage = "Name length up to 250 characters")]
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Admin CreatedBy { get; set; } = null!;
    public Admin ModifiedBy { get; set; } = null!;
    public ICollection<GymRule> GymRules { get; set; } = new List<GymRule>();
}
