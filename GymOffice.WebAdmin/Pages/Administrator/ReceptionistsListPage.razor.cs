namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class ReceptionistsListPage : ComponentBase
{
    private string searchString = "";    
    public Receptionist? Receptionist { get; set; }
    public ReceptionistVM? ReceptionistVM { get; set; } = new();
    public string? ErrorMessage { get; set; }
    public List<Receptionist>? Receptionists { get; set; }
    public ReceptionistSearchOptions SearchOptions { get; set; } = new();

    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        Receptionists = (List<Receptionist>?)await EmployeeDataProvider.GetReceptionistsAsync();
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }

    private bool FilterFunc1(Receptionist receptionist) => FilterFunc(receptionist, searchString);

    private bool FilterFunc(Receptionist receptionist, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (receptionist.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (receptionist.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (receptionist.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (receptionist.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }

    private async void EditReceptionist_Click(Receptionist receptionist)
    {
        ReceptionistVM = receptionist.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("ReceptionistModel", ReceptionistVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateEditReceptionistDialog>("CreateEditReceptionistDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Receptionists = (List<Receptionist>?)await EmployeeDataProvider.GetReceptionistsAsync();
            StateHasChanged();
        }
    }

    private async void CreateReceptionist_Click()
    {        
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("ReceptionistModel", null);
        parameters.Add("IsEdit", false);
        var dialog = DialogService.Show<CreateEditReceptionistDialog>("CreateEditReceptionistDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Receptionists = (List<Receptionist>?)await EmployeeDataProvider.GetReceptionistsAsync();
            StateHasChanged();
        }
    }

    private void GoToPreview_Click(Receptionist receptionist)
    {
        NavigationManager.NavigateTo($"/admin/receptionists/{receptionist.Id}");
    }

    private async void HandleSearch(ReceptionistSearchOptions options)
    {
        SearchOptions = options;
        Receptionists = (List<Receptionist>?)await EmployeeDataProvider.SearchReceptionistsAsync(options);
        StateHasChanged();
    }

    private async Task HandleResetSearch()
    {
        SearchOptions = new();
        Receptionists = (List<Receptionist>?)await EmployeeDataProvider.GetReceptionistsAsync();
        StateHasChanged();
    }
}