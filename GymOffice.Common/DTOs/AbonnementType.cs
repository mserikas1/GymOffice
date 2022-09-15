namespace GymOffice.Common.DTOs;

public class AbonnementType
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? StartVisitTime { get; set; }
    public string? EndVisitTime { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string? Description { get; set; }
    public AbonnementDuration? Duration { get; set; }
}