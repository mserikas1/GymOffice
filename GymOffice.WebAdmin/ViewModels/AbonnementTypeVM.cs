using GymOffice.Common.Utilities.Enums;

namespace GymOffice.WebAdmin.ViewModels;

public class AbonnementTypeVM
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [Display(Name = "Start visit time")]
    [DataType(DataType.Time)]
    public TimeSpan? StartVisitTime { get; set; } = new(0, 0, 0);

    [Required]
    [Display(Name = "End visit time")]
    [DataType(DataType.Time)]
    public TimeSpan? EndVisitTime { get; set; } = new(0, 0, 0);

    [Required]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Active")]
    public bool IsActive { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Required]
    public AbonnementDuration Duration { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public Admin CreatedBy { get; set; } = null!;

    public Admin ModifiedBy { get; set; } = null!;

    public ICollection<Abonnement> Abonnements { get; set; } = new List<Abonnement>();
}
