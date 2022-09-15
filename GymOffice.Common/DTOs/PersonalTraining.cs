namespace GymOffice.Common.DTOs;

public class PersonalTraining
{
    public Guid Id { get; set; }
    public DateTime ScheduledStartDate { get; set; }
    public DateTime ScheduledEndDate { get; set; }
    public string? Description { get; set; }
    public Guid VisitorId { get; set; }
    public Visitor? Visitor { get; set; }
    public Guid CoachId { get; set; }
    public Coach? Coach { get; set; }
}