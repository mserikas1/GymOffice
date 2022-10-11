using GymOffice.Common.DTOs;

namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class AdvantagesListPage : ComponentBase
{
    public Advantage? Advantage { get; set; }
    public AdvantageVM? AdvantageVM { get; set; } = new();
    public string? ErrorMessage { get; set; }
    public List<Advantage>? Advantages { get; set; }
    public AdvantageSearchOptions SearchOptions { get; set; } = new();

    [Inject]
    public IAdvantageDataProvider AdvantageDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        Advantages = (List<Advantage>?)await AdvantageDataProvider.GetAdvantagesAsync();
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }

    private async void EditAdvantage_Click(Advantage advantage)
    {
        AdvantageVM = advantage.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters
        {
            { "AdvantageModel", AdvantageVM },
            { "IsEdit", true }
        };
        var dialog = DialogService.Show<CreateEditAdvantageDialog>("CreateEditAdvantageDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Advantages = (List<Advantage>?)await AdvantageDataProvider.GetAdvantagesAsync();
            StateHasChanged();
        }
    }

    private async void CreateAdvantage_Click()
    {        
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters
        {
            { "AdvantageModel", null },
            { "IsEdit", false }
        };
        var dialog = DialogService.Show<CreateEditAdvantageDialog>("CreateEditAdvantageDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Advantages = (List<Advantage>?)await AdvantageDataProvider.GetAdvantagesAsync();
            StateHasChanged();
        }
    }

    private void GoToPreview_Click(Advantage advantage)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters
        {
            { "Advantage", advantage }
        };
        DialogService.Show<AdvantageViewItemDialog>("ViewAdvantageDialog", parameters, options);
    }

    private async void HandleSearch(AdvantageSearchOptions options)
    {
        SearchOptions = options;
        Advantages = (List<Advantage>?)await AdvantageDataProvider.SearchAdvantagesAsync(options);
        StateHasChanged();
    }

    private async Task HandleResetSearch()
    {
        SearchOptions = new();
        Advantages = (List<Advantage>?)await AdvantageDataProvider.GetAdvantagesAsync();
        StateHasChanged();
    }
}