namespace GymOffice.WebAdmin.Pages;
public partial class VisitorsListPage : ComponentBase
{
    private string? visitorSearchString;
    private Visitor? changedVisitor;

    public Visitor? Visitor { get; set; }
    public VisitorVM? VisitorVM { get; set; } = new();
    public string? ErrorMessage { get; set; }
    public List<Visitor>? Visitors { get; set; } = new List<Visitor>();
    public bool IsAdminRole { get; set; }
    public VisitorSearchOptions SearchOptions { get; set; } = new();

    [Inject]
    public IVisitorDataProvider VisitorDataProvider { get; set; } = null!;
    [Inject]
    public IUpdateVisitorCommand UpdateVisitorCommand { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Visitors = await GetVisitorsAsync();
            StateHasChanged();
        }
    }

    private async Task<List<Visitor>?> GetVisitorsAsync()
    {
        if (IsAdminRole)
        {
            return (List<Visitor>?)await VisitorDataProvider.GetAllVisitorsAsync();
        }

        return (List<Visitor>?)await VisitorDataProvider.GetActiveVisitorsAsync();
    }

    private async void EditVisitor_Click(Visitor visitor)
    {
        VisitorVM = visitor.ConvertToViewModel();

        DialogOptions options = GetDialogOptions();
        options.MaxWidth = MaxWidth.Small;
        var parameters = new DialogParameters();
        parameters.Add("VisitorModel", VisitorVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateVisitorDialog>("CreateVisitorDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Visitors = (List<Visitor>?)await VisitorDataProvider.GetAllVisitorsAsync();
            StateHasChanged();
        }
    }

    private async void CreateVisitor_Click()
    {
        DialogOptions options = GetDialogOptions();
        var parameters = new DialogParameters();
        parameters.Add("VisitorModel", null);
        parameters.Add("IsEdit", false);
        var dialog = DialogService.Show<CreateVisitorDialog>("New visitor registration", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Visitors = await GetVisitorsAsync();
            StateHasChanged();
        }
    }

    private DialogOptions GetDialogOptions()
    {
        return new DialogOptions
        {
            CloseOnEscapeKey = true,
            FullWidth = true,
            MaxWidth = string.IsNullOrEmpty(VisitorVM?.PhotoUrl) ? MaxWidth.Small : MaxWidth.Medium,
            NoHeader = true
        };
    }

    //private async void RegisterNewVisitorClick()
    //{
    //    var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, CloseButton = true };
    //    var parameters = new DialogParameters();
    //    parameters.Add("VisitorModel", null);
    //    var dialog = DialogService.Show<CreateVisitorDialog>("New visitor registration", parameters, options);
    //    await dialog.Result;
    //}

    private void GoToPreview_Click(Visitor visitor)
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            FullWidth = true,
            MaxWidth = visitor.PhotoUrl == null ? MaxWidth.Small : MaxWidth.Medium,
            NoHeader = true
        };
        var parameters = new DialogParameters();
        parameters.Add("Visitor", visitor);
        DialogService.Show<VisitorViewDialog>("VisitorViewDialog", parameters, options);
    }

    private async Task OnVisitorSearch(string text)
    {
        visitorSearchString = text;
        await VisitorsReloadAsync();
    }

    private async Task VisitorsReloadAsync()
    {
        Visitors = await GetVisitorsAsync();
        if (!string.IsNullOrWhiteSpace(visitorSearchString))
        {
            Visitors = Visitors?
                .Where(c => $"{c.FirstName} {c.LastName} {c.Email} {c.PhoneNumber} {c.VisitorCard.BarCode}"
                       .Contains(visitorSearchString, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        StateHasChanged();
    }

    private async Task IsInGymChanged(Visitor currentVisitor)
    {
        changedVisitor = currentVisitor;
        if (changedVisitor != null)
        {
            changedVisitor.IsInGym = !changedVisitor.IsInGym;
            await UpdateVisitorCommand.ExecuteAsync(changedVisitor);
        }
        StateHasChanged();
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }



    private async void HandleSearch(VisitorSearchOptions options)
    {
        SearchOptions = options;
        Visitors = (List<Visitor>?)await VisitorDataProvider.SearchVisitorsAsync(options);
        StateHasChanged();
    }

    private async Task HandleResetSearch()
    {
        SearchOptions = new();
        Visitors = (List<Visitor>?)await VisitorDataProvider.GetAllVisitorsAsync();
        StateHasChanged();
    }
}