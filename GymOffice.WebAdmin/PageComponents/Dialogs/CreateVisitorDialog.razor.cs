namespace GymOffice.WebAdmin.PageComponents.Dialogs;
public partial class CreateVisitorDialog : ComponentBase
{
    private VisitorCard? visitorCard;
    private Admin? admin;
    private string? errorMessage;
    private bool isActiveOriginal;
    private string? phoneNumberOriginal;
    public bool IsAdminRole { get; set; }
    public List<AbonnementType>? AbonnementTypes { get; set; }
    public Dictionary<string, List<AbonnementDuration>> DurationByName { get; set; } = new();
    public string AbonnementName { get; set; } = string.Empty;
    public AbonnementDuration AbonnementDuration { get; set; }
    public decimal AbonnementPrice { get; set; }
    public Abonnement? Abonnement { get; set; }
    public AbonnementType? OperationAbonnementType { get; set; }


    [Parameter]
    public VisitorVM? VisitorModel { get; set; } = new VisitorVM();
    [Parameter]
    public bool IsEdit { get; set; }

    [CascadingParameter]
    public MudDialogInstance DialogInstance { get; set; } = null!;

    [Inject]
    public IAbonnementTypeDataProvider AbonnementTypeDataProvider { get; set; } = null!;
    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public IAddVisitorCardCommand AddVisitorCardCommand { get; set; } = null!;
    [Inject]
    public IEditVisitorCommand EditVisitorCommand { get; set; } = null!;

    protected async override Task OnInitializedAsync()
    {
        try
        {
            admin = GetAdmin();
            AbonnementTypes = await GetAbonementTypesAsync();
            if (AbonnementTypes != null)
            {
                var durationsByName = AbonnementTypes.GroupBy(x => x.Name)
                    .Select(g => new { Name = g.Key, Durations = g.Select(t => t.Duration).Distinct().ToList() });

                foreach (var item in durationsByName)
                {
                    DurationByName.Add(item.Name, item.Durations);
                }
                AbonnementName = DurationByName.FirstOrDefault().Key;
                AbonnementDuration = DurationByName.FirstOrDefault().Value.FirstOrDefault();
            }

            if (IsEdit)
            {
                isActiveOriginal = VisitorModel!.IsActive;
                phoneNumberOriginal = VisitorModel!.PhoneNumber;
            }
            else
            {
                InitiateVisitorModel();
            }
            StateHasChanged();
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
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
        VisitorModel = new VisitorVM
        {
            Id = Guid.NewGuid(),
            RegistrationDate = DateTime.Now,
            IsActive = true,
            PhotoUrl = null,
            IsInGym = false
        };
        if (visitorCard != null)
        {
            VisitorModel.VisitorCard = visitorCard;
        };

        OperationAbonnementType = GetAbonementType();
        Abonnement = new Abonnement
        {
            Id = Guid.NewGuid(),
            AbonnementType = OperationAbonnementType!,
            IssueTime = DateTime.Now,
            ActivationTime = DateTime.Now,
            IsActive = true,
            CreatedBy = admin!,
            SoldPrice = OperationAbonnementType!.Price,
            TrainingVisits = new List<TrainingVisit>(),
            VisitorCard = visitorCard!
        };
    }

    private async Task<List<AbonnementType>?> GetAbonementTypesAsync()
    {
        return (List<AbonnementType>?)await AbonnementTypeDataProvider.GetActiveTypesAsync();
    }

    private async void HandleValidSubmit()
    {
        if (CheckForAnyChanges() == false)
        {
            DialogInstance.Close();
            return;
        }
        if (IsEdit)
        {
            visitorCard = VisitorModel!.VisitorCard;
        }
        Visitor visitor = VisitorModel!.ConvertToDto(visitorCard!);

        //if (visitor != null && visitorCard != null && visitor.VisitorCard == visitorCard && Abonnement != null)
        //{
        //    //visitorCard.Visitor = visitor;

            try
            {
                if (IsEdit)
                {
                    await EditVisitorCommand.ExecuteAsync(visitor);
                }
                else
                {
                    if (visitor != null && visitorCard != null && visitor.VisitorCard == visitorCard && Abonnement != null)
                    {
                        var type = GetAbonementType();
                        Abonnement.AbonnementType = type!;
                        Abonnement.SoldPrice = type!.Price;
                        visitorCard.Abonnements.Add(Abonnement);

                        await AddVisitorCardCommand.ExecuteAsync(visitor.VisitorCard); // Visitors are added to DB _automatically_ with the VisitorCard

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        //}

        StateHasChanged();
        DialogInstance.Close();
    }

    private bool CheckForAnyChanges()
    {
        return (isActiveOriginal != VisitorModel!.IsActive ||
            phoneNumberOriginal != VisitorModel!.PhoneNumber);
    }

    private Admin? GetAdmin()
    {
        return EmployeeDataProvider.GetAdministrators()?.FirstOrDefault();
    }

    private AbonnementType? GetAbonementType()
    {
        return AbonnementTypes?.FirstOrDefault(t => t.Name == AbonnementName && t.Duration == AbonnementDuration);
    }

    private void GetAbonnementPrice()
    {
        var abonType = GetAbonementType();
        if (abonType != null)
            AbonnementPrice = abonType.Price;
        StateHasChanged();
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