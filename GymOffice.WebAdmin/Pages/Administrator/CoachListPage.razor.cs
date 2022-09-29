namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class CoachListPage : ComponentBase
{
    public Coach? Coach { get; set; }
    public CoachVM? CoachVM { get; set; } = new();
    public string? ErrorMessage { get; set; }
    public List<Coach>? Coaches { get; set; }
    public CoachSearchOptions SearchOptions { get; set; } = new();

    [Inject]
    public ICoachDataProvider CoachDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        Coaches = (List<Coach>?)await CoachDataProvider.GetAllCoachesAsync();
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
            Coaches = (List<Coach>?)await CoachDataProvider.GetAllCoachesAsync();
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
            Coaches = (List<Coach>?)await CoachDataProvider.GetAllCoachesAsync();
            StateHasChanged();
        }
    }

    private void GoToPreview_Click(Coach coach)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("Coach", coach);
        var dialog = DialogService.Show<CoachViewItemDialog>("ViewCoachDialog", parameters, options);
        //var result = await dialog.Result;

        //if (!result.Cancelled)
        //{
        //    Coaches = (List<Coach>?)await CoachDataProvider.GetAllCoachesAsync();
        //    StateHasChanged();
        //}
        //NavigationManager.NavigateTo($"/admin/coaches/{coach.Id}");
    }

    private async void HandleSearch(CoachSearchOptions options)
    {
        SearchOptions = options;
        Coaches = (List<Coach>?)await CoachDataProvider.SearchCoachsAsync(options);
        StateHasChanged();
    }

    private async Task HandleResetSearch()
    {
        SearchOptions = new();
        Coaches = (List<Coach>?)await CoachDataProvider.GetAllCoachesAsync();
        StateHasChanged();
    }
}