namespace GymOffice.Common.DTOs;

public class GroupTraining
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int MaxVisitorsNumber { get; set; }
    public TimeOnly? StartTime { get; set; }//save in datetime?
    public string? EndTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }//list
    public string? Description { get; set; }
    public Guid? CoachId { get; set; }
    public Coach? Coach { get; set; }
    public List<Visitor>? Visitors { get; set; }
}