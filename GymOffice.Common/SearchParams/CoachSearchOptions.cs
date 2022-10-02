namespace GymOffice.Common.SearchParams;
public class CoachSearchOptions
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public SelectedIItem IsActive { get; set; } = SelectedIItem.None;
    public SelectedIItem IsAtWork { get; set; } = SelectedIItem.None;
    public SelectedIItem HasPersonalTraining { get; set; } = SelectedIItem.None;
    public SelectedIItem HasGroupTraining { get; set; } = SelectedIItem.None;

    public bool IsNullOrEmpty()
    {
        return (string.IsNullOrEmpty(FirstName) &&
                string.IsNullOrEmpty(LastName) &&
                string.IsNullOrEmpty(Phone) &&
                string.IsNullOrEmpty(Email) &&
                IsActive == SelectedIItem.None &&
                IsAtWork == SelectedIItem.None &&
                HasPersonalTraining == SelectedIItem.None &&
                HasGroupTraining == SelectedIItem.None);
    }
}
