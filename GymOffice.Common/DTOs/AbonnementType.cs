namespace GymOffice.Common.DTOs;

public class AbonnementType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string StartVisitTime { get; set; } = null!;
    public string EndVisitTime { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string? Description { get; set; }
    public AbonnementDuration Duration { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Admin CreatedBy { get; set; } = null!;
    public Admin ModifiedBy { get; set; } = null!;
    public ICollection<Abonnement> Abonnements { get; set; }= new List<Abonnement>();
}