namespace GymOffice.Common.DTOs;
public class JobSchedule
{
    public Guid Id { get; set; }
    public Coach? Coach { get; set; }
    public Receptionist? Receptionist { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public string StartTime { get; set; } = null!;
    public string EndTime { get; set; } = null!;
    public int? DayOfMonth { get; set; }
    public DateTime? SpecificDate { get; set; }
    public Admin CreatedBy { get; set; } = null!;
    public Admin ModifiedBy { get; set; } = null!;
}
