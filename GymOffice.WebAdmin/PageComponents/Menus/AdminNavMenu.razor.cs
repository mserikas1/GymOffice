﻿namespace GymOffice.WebAdmin.PageComponents.Menus;
public partial class AdminNavMenu : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;

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
            NavigationManager.NavigateTo("/admin/receptionists");
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
            NavigationManager.NavigateTo("/admin/coaches");
        }
    }

    private async void CreateAbonnementType_Click()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("AbonnementTypeModel", null);
        parameters.Add("IsEdit", false);
        var dialog = DialogService.Show<CreateEditAbonnementTypeDialog>("CreateEditAbonnementTypeDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            NavigationManager.NavigateTo("/admin/abonnement_types");
        }
    }
}  
