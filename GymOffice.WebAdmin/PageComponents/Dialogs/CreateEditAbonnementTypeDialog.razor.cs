namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class CreateEditAbonnementTypeDialog : ComponentBase
{
    private Admin? admin;
    private string? errorMessage;
    private bool isActiveOriginal;
    private decimal priceOriginal;
    private string? descriptionOriginal;

    [Parameter]
    public bool IsEdit { get; set; }
    [Parameter]
    public AbonnementTypeVM? AbonnementTypeModel { get; set; } = new();

    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IEditAbonnementTypeCommand EditAbonnementTypeCommand { get; set; } = null!;
    [Inject]
    public IAddAbonnementTypeCommand AddAbonnementTypeCommand { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;


    protected override void OnInitialized()
    {
        try
        {
            admin = GetAdmin();
            if (IsEdit)
            {
                isActiveOriginal = AbonnementTypeModel!.IsActive;
                priceOriginal = AbonnementTypeModel!.Price;
                descriptionOriginal = AbonnementTypeModel!.Description;
            }
            else
            {
                InitialAbonnementTypeModel();
            }
            StateHasChanged();
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
    }

    private Admin? GetAdmin()
    {
        return EmployeeDataProvider.GetAdministrators()?.FirstOrDefault();
    }

    private void InitialAbonnementTypeModel()
    {
        AbonnementTypeModel = new AbonnementTypeVM();
        if (admin != null)
        {
            AbonnementTypeModel.CreatedBy = admin;
            AbonnementTypeModel.ModifiedBy = admin;
        }
        AbonnementTypeModel.Id = Guid.NewGuid();
        AbonnementTypeModel.Duration = AbonnementDuration.Month;
        AbonnementTypeModel.IsActive = true;
        AbonnementTypeModel.CreatedAt = DateTime.Now;
    }

    private async void HandleValidSubmit()
    {
        if (CheckForAnyChanges() == false)
        {
            DialogInstance.Close();
            return;
        }

        try
        {
            AbonnementTypeModel!.ModifiedAt = DateTime.Now;
            AbonnementType abonnementType = AbonnementTypeModel!.ConvertToDto();
            if (IsEdit)
            {
                await EditAbonnementTypeCommand.ExecuteAsync(abonnementType);
            }
            else
            {
                await AddAbonnementTypeCommand.ExecuteAsync(abonnementType);
            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            DisplayErrorDialog(errorMessage);
        }

        StateHasChanged();
        DialogInstance.Close();
    }

    private void DisplayErrorDialog(string message)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = false, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters
        {
            { "ErrorMessage", message }
        };
        DialogService.Show<ErrorDisplay>("ErrorDisplayDialog", parameters, options);
    }

    private bool CheckForAnyChanges()
    {
        return (isActiveOriginal != AbonnementTypeModel!.IsActive ||
            descriptionOriginal != AbonnementTypeModel!.Description ||
            priceOriginal != AbonnementTypeModel!.Price);
    }

    private void HandleFormReset()
    {
        InitialAbonnementTypeModel();
        StateHasChanged();
    }

    private void HandleResetError()
    {
        errorMessage = null;
        InitialAbonnementTypeModel();
        StateHasChanged();
    }

    private void HandleCancel()
    {
        DialogInstance.Cancel();
    }
}