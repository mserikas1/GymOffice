namespace GymOffice.Common.DTOs;
public class Customer
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; }
    public string? PhotoPath { get; set; }
    public bool IsActive { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<Abonnement>? Abonnements { get; set; }
    public List<PersonalTraining>? PersonalTrainings { get; set; }
    public List<GroupTraining>? GroupTrainings { get; set; }
}
