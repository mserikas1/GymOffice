namespace GymOffice.Common.DTOs;
public class Coach
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? PhotoPath { get; set; }
    public bool IsOnWork { get; set; }
    public bool IsActive { get; set; }
    public string PassportNumber { get; set; } = null!;
    public string? Education { get; set; }
    public string? Description { get; set; }
    public List<PersonalTraining>? PersonalTrainings { get; set; }
    public List<GroupTraining>? GroupTrainings { get; set; }
}
