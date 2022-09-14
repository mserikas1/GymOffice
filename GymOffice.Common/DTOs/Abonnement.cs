namespace GymOffice.Common.DTOs;

public class Abonnement
{
    public Guid Id { get; set; }
    public DateTime IssueTime { get; set; }
    public DateTime? ActivationTime { get; set; }
    public Guid? TypeId { get; set; }
    public AbonnementType? AbonnementType { get; set; }
    public Guid VisitorId { get; set; }
    public Visitor Visitor { get; set; } = null!;
    public decimal SoldPice { get; set; }
    public bool IsActive { get; set; }
}