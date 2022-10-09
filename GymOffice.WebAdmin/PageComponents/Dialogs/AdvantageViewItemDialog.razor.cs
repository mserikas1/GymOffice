using System;

namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class AdvantageViewItemDialog : ComponentBase
{
    [Parameter]
    public Advantage? Advantage { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public IAdvantageDataProvider AdvantageDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;


    private async void EditAdvantage_Click()
    {
        if (Advantage == null)
        {
            ErrorMessage = "Something went wrong. Try again.";
            DisplayErrorDialog(ErrorMessage);
            StateHasChanged();
            return;
        }

        AdvantageVM advantageVM = Advantage.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("AdvantageModel", advantageVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateEditAdvantageDialog>("CreateEditAdvantageDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Advantage = await AdvantageDataProvider.GetAdvantageByIdAsync(advantageVM.Id);
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