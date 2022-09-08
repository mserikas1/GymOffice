namespace GymOffice.Common.DTOs;
public class Coach
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Email { get; set; }
    public string? Education { get; set; }
    public string? Description { get; set; }
    public string? PhotoPath { get; set; }
    public List<Training>? CurrentTrainings { get; set; }
}
