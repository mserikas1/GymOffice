namespace GymOffice.Common.DTOs;

public class Abonnement
{
    public Guid Id { get; set; }
    public DateTime IssueTime { get; set; }
    public DateTime ActivationTime { get; set; }
    public AbonnementType AbonnementType { get; set; } = null!;
    public VisitorCard VisitorCard { get; set; } = null!;
    public decimal SoldPrice { get; set; }
    public bool IsActive { get; set; }
    public Employee CreatedBy { get; set; } = null!;
    public ICollection<TrainingVisit> TrainingVisits { get; set; } = new List<TrainingVisit>();
}