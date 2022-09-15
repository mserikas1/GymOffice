namespace GymOffice.Common.DTOs;
public class Coach
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string PhotoUrl { get; set; } = null!;
    public bool IsAtWork { get; set; }
    public bool IsActive { get; set; }
    public string Email { get; set; } = null!;
    public string PassportNumber { get; set; } = null!;
    public string? Education { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Admin CreatedBy { get; set; } = null!;
    public Admin ModifiedBy { get; set; } = null!;
    public ICollection<JobSchedule> JobScheduleItems { get; set; } = new List<JobSchedule>();
    public ICollection<PersonalTraining> PersonalTrainings { get; set; } = new List<PersonalTraining>();
    public ICollection<GroupTraining> GroupTrainings { get; set; } = new List<GroupTraining>();
}
