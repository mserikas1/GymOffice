namespace GymOffice.Common.DTOs;

public class GroupTraining
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int MaxCustomersNumber { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public string? Description { get; set; }
    public Guid CoachId { get; set; }
}