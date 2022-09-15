namespace GymOffice.Common.DTOs;

public class GroupTraining
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int MaxVisitorsNumber { get; set; }
    public string? StartTime { get; set; }//save in datetime?
    public string? EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }//list
    public string? Description { get; set; }
    public Coach? Coach { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Admin CreatedBy { get; set; } = null!;
    public Admin ModifiedBy { get; set; } = null!;
    public ICollection<Visitor> Visitors { get; set; } = new List<Visitor>();
}