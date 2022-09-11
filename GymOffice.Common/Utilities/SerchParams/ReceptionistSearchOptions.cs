namespace GymOffice.Common.Utilities.SerchParams;
public class ReceptionistSearchOptions
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public bool? IsActive { get; set; }
    public Role Role { get; } = Role.Receptionist;
}
