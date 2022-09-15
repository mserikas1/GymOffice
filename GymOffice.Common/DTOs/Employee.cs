namespace GymOffice.Common.DTOs;
public abstract class Employee
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhotoUrl { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public string? PassportNumber { get; set; }
}
