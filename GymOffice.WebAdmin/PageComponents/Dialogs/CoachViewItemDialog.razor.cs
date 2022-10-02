using System;

namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class CoachViewItemDialog : ComponentBase
{
    [Parameter]
    public Coach? Coach { get; set; }
    public string? ErrorMessage { get; set; }

    [Inject]
    public ICoachDataProvider CoachDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;


    private async void EditCoach_Click()
    {
        if (Coach == null)
        {
            ErrorMessage = "Something went wrong. Try again.";
            DisplayErrorDialog(ErrorMessage);
            StateHasChanged();
            return;
        }

        CoachVM coachVM = Coach.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("CoachModel", coachVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateEditCoachDialog>("CreateEditCoachDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Coach = await CoachDataProvider.GetCoachByIdAsync(coachVM.Id);
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