namespace GymOffice.Common.DTOs;
public class Visitor
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; } 
    public string? PhotoUrl { get; set; }
    public string? Email { get; set; }
    public bool IsInGym { get; set; }
    public bool IsActive { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Guid VisitorCardId { get; set; }
    public VisitorCard VisitorCard { get; set; } = null!;
    public ICollection<PersonalTraining> PersonalTrainings { get; set; } = new List<PersonalTraining>();
    public ICollection<TrainingVisit> TrainingVisits { get; set; } = new List<TrainingVisit>();
    public ICollection<GroupTraining> GroupTrainings { get; set; } = new List<GroupTraining>();
}
