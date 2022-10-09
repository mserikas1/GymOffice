namespace GymOffice.Common.SearchParams;
public class AdvantageSearchOptions
{
    public string? Title { get; set; }

    public bool IsNullOrEmpty()
    {
        return (string.IsNullOrEmpty(Title));
    }
}
