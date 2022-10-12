namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class CreateEditGymRuleDialog : ComponentBase
{
    
    private Admin? admin;
    private string? descriptionOriginal;
    private bool isActiveOriginal;
    public string? ErrorMessage { get; set; }

    [Parameter]
    public bool IsEdit { get; set; }
    [Parameter]
    public GymRuleVM? RuleModel { get; set; }
    [Parameter]
    public RuleSection? RulesSection { get; set; }
    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;

    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IEditGymRuleCommand EditGymRuleCommand { get; set; } = null!;
    [Inject]
    public IAddGymRuleCommand AddGymRuleCommand { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;


    protected override void OnInitialized()
    {
        try
        {
            admin = GetAdmin();
            if (IsEdit)
            {
                isActiveOriginal = RuleModel!.IsActive;
                descriptionOriginal = RuleModel!.Description;
            }
            else
            {
                InitialRulesSectionModel();
            }
            StateHasChanged();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    private Admin? GetAdmin()
    {
        return EmployeeDataProvider.GetAdministrators()?.FirstOrDefault();
    }

    private void InitialRulesSectionModel()
    {
        RuleModel = new GymRuleVM();
        if (admin != null)
        {
            RuleModel.CreatedBy = admin;
            RuleModel.ModifiedBy = admin;
        }
        RuleModel.Id = Guid.NewGuid();
        RuleModel.IsActive = true;
        RuleModel.CreatedAt = DateTime.Now;
        if (RulesSection != null)
            RuleModel.Section = RulesSection;
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
            RuleModel!.ModifiedAt = DateTime.Now;
            GymRule rule = RuleModel!.ConvertToDto();
            if (IsEdit)
            {
                await EditGymRuleCommand.ExecuteAsync(rule);
            }
            else
            {
                await AddGymRuleCommand.ExecuteAsync(rule);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            DisplayErrorDialog(ErrorMessage);
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
        return (isActiveOriginal != RuleModel!.IsActive ||
            descriptionOriginal != RuleModel!.Description);
    }

    private void HandleFormReset()
    {
        InitialRulesSectionModel();
        StateHasChanged();
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        InitialRulesSectionModel();
        StateHasChanged();
    }

    private void HandleCancel()
    {
        DialogInstance.Cancel();
    }
}