namespace GymOffice.WebAdmin.Pages;

[Authorize(Roles = "Admin, Receptionist")]
public partial class CoachListPage : ComponentBase
{
    public Coach? Coach { get; set; }
    public CoachVM? CoachVM { get; set; } = new();
    public string? ErrorMessage { get; set; }
    public List<Coach>? Coaches { get; set; }
    public CoachSearchOptions SearchOptions { get; set; } = new();
    public bool CurrentUserIsAdmin { get; set; } = false;

    [Inject]
    public ICoachDataProvider CoachDataProvider { get; set; } = null!;
    [Inject]
    public IUpdateCoachCommand UpdateCoachCommand { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await GetCoacherListAsync();
            StateHasChanged();
        }
    }

    protected async Task GetCoacherListAsync()
    {
        if (CurrentUserIsAdmin)
            Coaches = (List<Coach>?)await CoachDataProvider.GetAllCoachesAsync();
        else
            Coaches = (List<Coach>?)await CoachDataProvider.GetActiveCoachesAsync();
        // await Task.Delay(100); // for db connection stability
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }

    private async void EditCoach_Click(Coach coach)
    {
        CoachVM = coach.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("CoachModel", CoachVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateEditCoachDialog>("CreateEditCoachDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            await GetCoacherListAsync();
            StateHasChanged();
        }
    }

    private async void CreateCoach_Click()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("CoachModel", null);
        parameters.Add("IsEdit", false);
        var dialog = DialogService.Show<CreateEditCoachDialog>("CreateEditCoachDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            await GetCoacherListAsync();
            StateHasChanged();
        }
    }

    private async Task IsAtWorkChanged(Coach currentCoach)
    {
        if (currentCoach != null)
        {
            currentCoach.IsAtWork = !currentCoach.IsAtWork;
            await UpdateCoachCommand.ExecuteAsync(currentCoach);
            StateHasChanged();
        }
    }
    private void GoToPreview_Click(Coach coach)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("Coach", coach);
        var dialog = DialogService.Show<CoachViewItemDialog>("ViewCoachDialog", parameters, options);
    }

    private async void HandleSearch(CoachSearchOptions options)
    {
        SearchOptions = options;
        // TODO make a corresponding option in CoachSearchOptions to exclude some fields from search for receptionist
        Coaches = (List<Coach>?)await CoachDataProvider.SearchCoachsAsync(options);
        StateHasChanged();
    }

    private async Task HandleResetSearch()
    {
        SearchOptions = new();
        await GetCoacherListAsync();
        StateHasChanged();
    }
}