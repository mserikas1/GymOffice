namespace GymOffice.Common.DTOs;

public class Training
{
    public Guid Id { get; set; }
    public DateTime ScheduledStartDate { get; set; }
    public DateTime ScheduledEndDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; }
    public Guid CustomerId { get; set; }
    public Guid CoachId { get; set; }
}