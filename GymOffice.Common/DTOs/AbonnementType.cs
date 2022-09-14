namespace GymOffice.Common.DTOs;

public class AbonnementType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string StartVisitTime { get; set; } = null!;
    public string EndVisitTime { get; set; } = null!;
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string Description { get; set; } =null!;
    public AbonnementDuration? Duration { get; set; }
}