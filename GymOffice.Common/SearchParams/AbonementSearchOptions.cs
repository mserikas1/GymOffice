namespace GymOffice.Common.SearchParams;
public class AbonnementSearchOptions
{
    public string? Type { get; set; } = "All";
    public string? Duration { get; set; } = "All";
    public decimal StartPrice { get; set; } = 0;
    public decimal EndPrice { get; set; } = 0;
    public DateTime? StartDay { get; set; } = new(2022, 1, 1);
    public DateTime? EndDay { get; set; } = DateTime.Now;
    public SelectedItem IsActive { get; set; } = SelectedItem.None;

    public bool IsNullOrEmpty()
    {
        return (Type == "All"  &&
                Duration == "All" &&
                StartPrice == 0 &&
                EndPrice == 0 &&
                StartDay == new DateTime(2022, 1, 1) &&
                EndDay == DateTime.Now &&
                IsActive == SelectedItem.None);
    }
}
