namespace GymOffice.Common.DTOs
{
    public class Receptionist:Employee
    {
        public bool IsAtWork { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Admin CreatedBy { get; set; } = null!;
        public Admin ModifiedBy { get; set; } = null!;
        public ICollection<JobSchedule> JobScheduleItems { get; set; } = new List<JobSchedule>();
    }
}
