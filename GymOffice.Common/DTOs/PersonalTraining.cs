namespace GymOffice.Common.DTOs;

public class PersonalTraining
{
    public Guid Id { get; set; }
    public DateTime ScheduledStartDate { get; set; }
    public DateTime ScheduledEndDate { get; set; }
    public string? Description { get; set; }
    public Visitor Visitor { get; set; } = null!;
    public Coach Coach { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Receptionist? CreatedByReceptionist { get; set; }
    public Receptionist? ModifiedByReceptionist { get; set; }
    public Coach? CreatedByCoach { get; set; }
    public Coach? ModifiedByCoach { get; set; }
}