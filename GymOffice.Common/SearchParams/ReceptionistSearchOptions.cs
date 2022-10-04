namespace GymOffice.Common.SearchParams;
public class ReceptionistSearchOptions
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public SelectedItem IsActive { get; set; } = SelectedItem.None;
    public SelectedItem IsAtWork { get; set; } = SelectedItem.None;

    public bool IsNullOrEmpty()
    {
        return (string.IsNullOrEmpty(FirstName) &&
                string.IsNullOrEmpty(LastName) &&
                string.IsNullOrEmpty(Phone) &&
                string.IsNullOrEmpty(Email) &&
                IsActive == SelectedItem.None &&
                IsAtWork == SelectedItem.None);
    }
}
