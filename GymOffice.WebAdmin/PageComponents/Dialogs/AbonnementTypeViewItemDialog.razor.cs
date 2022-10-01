namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class AbonnementTypeViewItemDialog : ComponentBase
{
    [Parameter]
    public AbonnementType? AbonnementType { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public IAbonnementTypeDataProvider AbonnementTypeDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    
    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;


    private async void EditAbonnementType_Click()
    {
        if (AbonnementType == null)
        {
            ErrorMessage = "Something went wrong. Try again.";
            DisplayErrorDialog(ErrorMessage);
            StateHasChanged();
            return;
        }

        AbonnementTypeVM abonnementTypeVM = AbonnementType.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("AbonnementTypeModel", abonnementTypeVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateEditAbonnementTypeDialog>("CreateEditAbonnementTypeDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            AbonnementType = await AbonnementTypeDataProvider.GetByIdAsync(abonnementTypeVM.Id);
            StateHasChanged();
        }
    }

    private void DisplayErrorDialog(string message)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = false, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("ErrorMessage", message);
        var dialog = DialogService.Show<ErrorDisplay>("ErrorDisplayDialog", parameters, options);
    }

    private void HandleClose_Click()
    {
        DialogInstance.Close();
    }
}