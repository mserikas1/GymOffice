namespace GymOffice.Common.DTOs;
public abstract class Employee
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; }
    public string? PhotoPath { get; set; }
    public bool IsActive { get; set; }
    public string PassportNumber { get; set; } = null!;
    //public virtual Role Role { get; set; }
}
