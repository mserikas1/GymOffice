namespace GymOffice.Common.DTOs;
public class GroupTrainingRecord
{
    public Guid Id { get; set; }
    public Guid GroupTrainingId { get; set; }
    public GroupTraining GroupTraining { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
}
