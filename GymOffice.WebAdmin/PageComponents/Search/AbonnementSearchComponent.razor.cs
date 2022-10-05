namespace GymOffice.WebAdmin.PageComponents.Search;
public partial class AbonnementSearchComponent : ComponentBase
{
    [Parameter]
    public bool IsAdminRole { get; set; }
    [Parameter]
    public AbonnementSearchOptions SearchOptions { get; set; } = null!;
    [Parameter]
    public EventCallback<AbonnementSearchOptions> HandleSearch_Click { get; set; }
    [Parameter]
    public EventCallback HandleResetSearch_Click { get; set; }

    public List<string>? AbonnementTypeNames { get; set; } = new();
    public List<string>? Durations { get; set; } = new();

    [Inject]
    public IAbonnementTypeDataProvider AbonnementTypeDataProvider { get; set; } = null!;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var abonnementTypes = (await AbonnementTypeDataProvider.GetAllAbonnementTypesAsync())?.ToList();
            AbonnementTypeNames = abonnementTypes?.Select(x => x.Name).Distinct().ToList();
            AbonnementTypeNames?.Insert(0, "All");

            foreach (AbonnementDuration item in Enum.GetValues(typeof(AbonnementDuration)))
            {
                Durations?.Add(item.ToString());
            }
            Durations?.Insert(0, "All");
        }
    }

    private string ChangeDurationString(string duration)
    {
        string changedString = string.Empty;
        foreach (AbonnementDuration item in Enum.GetValues(typeof(AbonnementDuration)))
        {
            if (duration == item.ToString())
            {
                changedString = ((int)item).ToString() + " " + ((int)item == 1 ? "month" : "months");
            }
            if (duration == "All")
            {
                changedString = duration;
            }
        }
        return changedString;
    }
}