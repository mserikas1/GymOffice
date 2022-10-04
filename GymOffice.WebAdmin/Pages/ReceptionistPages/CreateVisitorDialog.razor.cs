namespace GymOffice.WebAdmin.Pages.ReceptionistPages;
public partial class CreateVisitorDialog : ComponentBase
{
    private VisitorCard? visitorCard;
    private Admin? admin;
    private string? errorMessage;

    [Parameter]
    public VisitorVM? visitorModel { get; set; } = new VisitorVM();

    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;

    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IAddVisitorCardCommand AddVisitorCardCommand { get; set; } = null!;
    [Inject]
    public IIdentityRepository IdentityRepository { get; set; } = null!;

    protected override void OnInitialized()
    {
        try
        {
            admin = GetAdmin();
            InitiateVisitorModel();
            StateHasChanged();
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
    }

    private async void HandleValidSubmit()
    {
        var visitor = visitorModel?.ConvertToDto(visitorCard!);

        if (visitor != null && visitorCard != null && visitor.VisitorCard == visitorCard)
        {
            visitorCard.Visitor = visitor;
            try
            {
                await AddVisitorCardCommand.ExecuteAsync(visitor.VisitorCard); // Visitors are added to DB _automatically_ with the VisitorCard
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        DialogInstance.Close();
    }

    private Admin? GetAdmin()
    {
        return EmployeeDataProvider.GetAdministrators()?.FirstOrDefault();
    }

    private void InitiateVisitorModel()
    {
        Random r = new();
        visitorCard = new VisitorCard()
        {
            Id = Guid.NewGuid(),
            RegistrationDate = DateTime.Now,
            CreatedAt = DateTime.Now,
            IsActive = true,
            BarCode = $"482{r.NextInt64(1000000000, 9999999999)}",
        };
        if (visitorCard != null && admin != null)
        {
            visitorCard.CreatedBy = admin;
        }
        visitorModel = new VisitorVM
        {
            Id = Guid.NewGuid(),
            RegistrationDate = DateTime.Now,
            IsActive = true,
            PhotoUrl = null,
            IsInGym = false
        };
        if (visitorCard != null)
        {
            visitorModel.VisitorCard = visitorCard;
        };
    }

    private void HandleResetError()
    {
        errorMessage = null;
        admin = GetAdmin();
        InitiateVisitorModel();
        StateHasChanged();
    }

    private void HandleFormReset()
    {
        InitiateVisitorModel();
        StateHasChanged();
    }

    private void HandleCancel()
    {
        DialogInstance.Cancel();
    }
}