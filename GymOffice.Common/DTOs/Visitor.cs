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
    public VisitorCard? VisitorCard { get; set; }
    public List<Abonnement>? Abonnements { get; set; }
    public List<PersonalTraining>? PersonalTrainings { get; set; }
    public List<TrainingVisit>? TrainingVisits { get; set; }
    public List<GroupTraining>? GroupTrainings { get; set; }
}
