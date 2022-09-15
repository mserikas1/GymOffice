namespace GymOffice.Common.DTOs;
public class Coach
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhotoUrl { get; set; }
    public bool IsAtWork { get; set; }
    public bool IsActive { get; set; }
    public string? Email { get; set; }
    public string? PassportNumber { get; set; }
    public string? Education { get; set; }
    public string? Description { get; set; }
    public List<PersonalTraining>? PersonalTrainings { get; set; }
    public List<GroupTraining>? GroupTrainings { get; set; }
}
