namespace GymOffice.Common.DTOs;
public class JobSchedule
{
    public Guid Id { get; set; }
    public Guid? CoachId { get; set; }
    public Coach? Coach { get; set; }
    public Guid? EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int? DayOfMonth { get; set; }
    public DateTime? SpecificDate { get; set; }
}
