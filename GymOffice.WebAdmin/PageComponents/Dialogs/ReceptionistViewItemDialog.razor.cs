namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class ReceptionistViewItemDialog : ComponentBase
{
    [Parameter]
    public Receptionist? Receptionist { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;


    private async void EditCoach_Click()
    {
        if (Receptionist == null)
        {
            ErrorMessage = "Something went wrong. Try again.";
            DisplayErrorDialog(ErrorMessage);
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
            Receptionist = await EmployeeDataProvider.GetReceptionistByIdAsync(receptionistVM.Id);
            StateHasChanged();
        }
    }

    private void DisplayErrorDialog(string message)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = false, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("ErrorMessage", message);
        DialogService.Show<ErrorDisplay>("ErrorDisplayDialog", parameters, options);
    }

    private void HandleClose_Click()
    {
        DialogInstance.Close();
    }
}
