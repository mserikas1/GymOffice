namespace GymOffice.WebAdmin.Pages;
public partial class AbonnementsListPage : ComponentBase
{
    public bool IsAdminRole { get; set; }
    public List<Abonnement>? Abonnements { get; set; } = new List<Abonnement>();
    public string? ErrorMessage { get; set; }
    public AbonnementSearchOptions SearchOptions { get; set; } = new();

    [Inject]
    public IAbonnementDataProvider AbonnementDataProvider { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        Abonnements = (List<Abonnement>?)await AbonnementDataProvider.GetAllAsync();
    }

    // Uncomment if we need to show for receptionist only active abonnements.
    //
    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{

    //        if (firstRender)
    //        {
    //            Abonnements = await GetAbonnementsAsync();
    //            StateHasChanged();
    //        }
    //}

    //private async Task<List<Abonnement>?> GetAbonnementsAsync()
    //{
    //    if (IsAdminRole)
    //    {
    //        return (List<Abonnement>?)await AbonnementDataProvider.GetAllAsync();
    //    }

    //    return (List<Abonnement>?)await AbonnementDataProvider.GetActiveAsync();
    //}


    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }

    private async void HandleSearch(AbonnementSearchOptions options)
    {
        SearchOptions = options;
        if (SearchOptions.StartPrice > SearchOptions.EndPrice)
        {
            SearchOptions.EndPrice = SearchOptions.StartPrice;
        }
        if (SearchOptions.StartDay > SearchOptions.EndDay)
        {
            SearchOptions.EndDay = SearchOptions.StartDay.Value.AddDays(1);
        }
        Abonnements = (List<Abonnement>?)await AbonnementDataProvider.SearchAbonnementsAsync(SearchOptions);
        StateHasChanged();
    }

    private async Task HandleResetSearch()
    {
        SearchOptions = new();
        Abonnements = (List<Abonnement>?)await AbonnementDataProvider.GetAllAsync();
        //Abonnements = await GetAbonnementsAsync();
        StateHasChanged();
    }
}