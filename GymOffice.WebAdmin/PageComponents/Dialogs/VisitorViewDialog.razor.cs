namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class VisitorViewDialog : ComponentBase
{
    public bool IsAdminRole { get; set; }
    public string? ErrorMessage { get; set; }

    [Parameter]
    public Visitor? Visitor { get; set; }

    [Inject]
    public IVisitorDataProvider VisitorDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    [CascadingParameter]
    MudDialogInstance? MudDialog { get; set; }

    // TODO redirecting to abonnement and training views

    private async void EditvisitorModel_Click()
    {
        if (Visitor == null)
        {
            ErrorMessage = "Something went wrong. Try again.";
            DisplayErrorDialog(ErrorMessage);
            StateHasChanged();
            return;
        }

        VisitorVM visitorVM = Visitor.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("VisitorModel", visitorVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateVisitorDialog>("CreateVisitorDialog", parameters, options);
        var result = await dialog.Result;
        MudDialog?.Close(DialogResult.Cancel);

        if (!result.Cancelled)
        {
            Visitor = await VisitorDataProvider.GetVisitorByIdAsync(visitorVM.Id);
            StateHasChanged();
        }
    }

    private void DisplayErrorDialog(string message)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = false, MaxWidth = MaxWidth.Small, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("ErrorMessage", message);
        DialogService.Show<ErrorDisplay>("ErrorDisplayDialog", parameters, options);
    }

    private void HandleResetError()
    {
        MudDialog?.Close(DialogResult.Cancel);
    }

    private void HandleClose_Click()
    {
        MudDialog?.Close(DialogResult.Cancel);
        //DialogInstance.Close();
    }
}