namespace GymOffice.Common.DTOs;
public class Visitor
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? PhotoPath { get; set; }
    public bool IsActive { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Guid VisitorCardId { get; set; }
    public VisitorCard? VisitorCard { get; set; }
    public List<Abonnement>? Abonnements { get; set; }
    public List<PersonalTraining>? PersonalTrainings { get; set; }
    public List<GroupTraining>? GroupTrainings { get; set; }
}
