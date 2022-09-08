namespace GymOffice.Common.DTOs;

public class AbonnementType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public TimeOnly StartVisitTime { get; set; }
    public TimeOnly EndVisitTime { get; set; }
    public decimal PriceForMonth { get; set; }
    public string Description { get; set; } =null!;
}