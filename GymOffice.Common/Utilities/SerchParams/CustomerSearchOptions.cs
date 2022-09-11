namespace GymOffice.Common.Utilities.SerchParams;
public class CustomerSearchOptions
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public bool? IsActive { get; set; }
    public bool? HasAbonnements { get; set; }
    public bool? HasGroupTrainings { get; set; }
    public bool? HasPersonalTrainings { get; set; }
    public DateTime? StartDate { get; set; } = new DateTime(2022, 1, 1);
    public DateTime? EndDate { get; set; } = DateTime.Now;
}
