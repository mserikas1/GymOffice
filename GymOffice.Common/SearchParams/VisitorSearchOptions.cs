namespace GymOffice.Common.SearchParams;
public class VisitorSearchOptions
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    
    public SelectedItem IsActive { get; set; } = SelectedItem.None;
    public SelectedItem IsInGym { get; set; } = SelectedItem.None;
    public SelectedItem HasPersonalTraining { get; set; } = SelectedItem.None;
    public SelectedItem HasGroupTraining { get; set; } = SelectedItem.None;
    public SelectedItem HasAbonnement { get; set; } = SelectedItem.None;

    public bool IsNullOrEmpty()
    {
        return (string.IsNullOrEmpty(FirstName) &&
                string.IsNullOrEmpty(LastName) &&
                string.IsNullOrEmpty(Phone) &&                
                IsActive == SelectedItem.None &&
                IsInGym == SelectedItem.None &&
                HasPersonalTraining == SelectedItem.None &&
                HasGroupTraining == SelectedItem.None &&
                HasAbonnement == SelectedItem.None);
    }
}
