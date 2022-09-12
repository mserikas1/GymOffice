namespace GymOffice.Common.DTOs;
public class Coach:Employee
{
    public string? Education { get; set; }
    public string? Description { get; set; }
    public List<PersonalTraining>? PersonalTrainings { get; set; }
    public List<GroupTraining>? GroupTrainings { get; set; }
}
