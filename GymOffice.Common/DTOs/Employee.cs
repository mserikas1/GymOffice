namespace GymOffice.Common.DTOs;
public abstract class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? PhotoUrl { get; set; }
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }
    public string PassportNumber { get; set; } = null!;
}
