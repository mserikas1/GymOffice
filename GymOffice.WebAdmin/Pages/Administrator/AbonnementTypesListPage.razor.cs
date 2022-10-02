namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class AbonnementTypesListPage : ComponentBase
{
    public AbonnementType? AbonnementType { get; set; }
    public AbonnementTypeVM? AbonnementTypeVM { get; set; } = new();
    public string? ErrorMessage { get; set; }
    public List<AbonnementType>? AbonnementTypes { get; set; }

    [Inject]
    public IAbonnementTypeDataProvider AbonnementTypeDataProvider { get; set; } = null!;    
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        AbonnementTypes = (List<AbonnementType>?)await AbonnementTypeDataProvider.GetAllAbonnementTypesAsync();
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }

    private async void EditAbonnementType_Click(AbonnementType type)
    {
        AbonnementTypeVM = type.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("AbonnementTypeModel", AbonnementTypeVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateEditAbonnementTypeDialog>("CreateEditAbonnementTypeDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            AbonnementTypes = (List<AbonnementType>?)await AbonnementTypeDataProvider.GetAllAbonnementTypesAsync();
            StateHasChanged();
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
            AbonnementTypes = (List<AbonnementType>?)await AbonnementTypeDataProvider.GetAllAbonnementTypesAsync();
            StateHasChanged();
        }
    }

    private void GoToPreview_Click(AbonnementType type)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters
        {
            { "AbonnementType", type }
        };
        DialogService.Show<AbonnementTypeViewItemDialog>("ViewAbonnementTypeDialog", parameters, options);
    }   
}