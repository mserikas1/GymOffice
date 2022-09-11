using GymOffice.Common.Utilities.Enums;

namespace GymOffice.Common.DTOs;

public class Abonnement
{
    public Guid Id { get; set; }
    public DateTime IssueTime { get; set; }
    public DateTime ActivationTime { get; set; }
    public Guid TypeId { get; set; }
    public Guid CustomerId { get; set; }
    public AbonnementDuration Duration { get; set; }
}