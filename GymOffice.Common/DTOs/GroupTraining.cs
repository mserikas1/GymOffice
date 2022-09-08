namespace GymOffice.Common.DTOs;

public class GroupTraining
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int MaxCustomersNumber { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public string? Description { get; set; }
    public Guid CoachId { get; set; }
    public Coach? Coach { get; set; }
    public List<Customer>? Customers { get; set; }
}