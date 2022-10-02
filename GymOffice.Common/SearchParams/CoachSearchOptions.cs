namespace GymOffice.Common.SearchParams;
public class CoachSearchOptions
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public SelectedItem IsActive { get; set; } = SelectedItem.None;
    public SelectedItem IsAtWork { get; set; } = SelectedItem.None;
    public SelectedItem HasPersonalTraining { get; set; } = SelectedItem.None;
    public SelectedItem HasGroupTraining { get; set; } = SelectedItem.None;

    public bool IsNullOrEmpty()
    {
        return (string.IsNullOrEmpty(FirstName) &&
                string.IsNullOrEmpty(LastName) &&
                string.IsNullOrEmpty(Phone) &&
                string.IsNullOrEmpty(Email) &&
                IsActive == SelectedItem.None &&
                IsAtWork == SelectedItem.None &&
                HasPersonalTraining == SelectedItem.None &&
                HasGroupTraining == SelectedItem.None);
    }
}
