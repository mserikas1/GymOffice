namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class CreateEditRulesSectionDialog : ComponentBase
{
    private Admin? admin;
    private string? nameOriginal;
    private bool isActiveOriginal;
    public string? ErrorMessage { get; set; }

    [Parameter]
    public bool IsEdit { get; set; }
    [Parameter]
    public RulesSectionVM? SectionModel { get; set; }
    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;

    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IEditRulesSectionCommand EditRulesSectionCommand { get; set; } = null!;
    [Inject]
    public IAddRulesSectionCommand AddRulesSectionCommand { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;


    protected override void OnInitialized()
    {
        try
        {
            admin = GetAdmin();
            if (IsEdit)
            {
                isActiveOriginal = SectionModel!.IsActive;
                nameOriginal = SectionModel!.Name;
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
        SectionModel = new RulesSectionVM();
        if (admin != null)
        {
            SectionModel.CreatedBy = admin;
            SectionModel.ModifiedBy = admin;
        }
        SectionModel.Id = Guid.NewGuid();
        SectionModel.IsActive = true;
        SectionModel.CreatedAt = DateTime.Now;
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
            SectionModel!.ModifiedAt = DateTime.Now;
            RuleSection section = SectionModel!.ConvertToDto();
            if (IsEdit)
            {
                await EditRulesSectionCommand.ExecuteAsync(section);
            }
            else
            {
                await AddRulesSectionCommand.ExecuteAsync(section);
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
        return (isActiveOriginal != SectionModel!.IsActive ||
            nameOriginal != SectionModel!.Name);
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