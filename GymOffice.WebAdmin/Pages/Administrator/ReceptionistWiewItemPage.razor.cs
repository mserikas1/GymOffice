namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class ReceptionistWiewItemPage : ComponentBase
{
    [Parameter]
    public Guid ReceptionistId { get; set; }
    public Receptionist? Receptionist { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Receptionist = await EmployeeDataProvider.GetReceptionistByIdAsync(ReceptionistId);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        NavigationManager.NavigateTo("/admin/receptionists");
    }

    private async void EditReceptionist_Click()
    {
        if (Receptionist == null)
        {
            ErrorMessage = "Something went wrong. Try again.";
            StateHasChanged();
            return;
        }

        ReceptionistVM receptionistVM = Receptionist.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("ReceptionistModel", receptionistVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateEditReceptionistDialog>("CreateEditReceptionistDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Receptionist = await EmployeeDataProvider.GetReceptionistByIdAsync(ReceptionistId);
            StateHasChanged();
        }
    }

    private void RedirectToReceptionistsList_Click()
    {
        NavigationManager.NavigateTo("/admin/receptionists");
    }
}