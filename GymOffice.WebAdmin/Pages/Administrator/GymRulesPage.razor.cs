namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class GymRulesPage : ComponentBase
{
    public string? ErrorMessage { get; set; }
    public GymRule? Rule { get; set; }
    public GymRuleVM? RuleVM { get; set; } = new();
    public List<GymRule>? Rules { get; set; }
    public List<RuleSection>? Sections { get; set; }
    public RuleSection? RulesSection { get; set; }
    public string SectionName { get; set; } = string.Empty;
    public RulesSectionVM? RulesSectionVM { get; set; } = new();

    [Inject]
    public IAddGymRuleCommand AddGymRuleCommand { get; set; } = null!;
    [Inject]
    public IEditGymRuleCommand EditGymRuleCommand { get; set; } = null!;
    [Inject]
    public IGymRulesDataProvider GymRulesDataProvider { get; set; } = null!;
    [Inject]
    public IDialogService DialogService { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        Sections = (List<RuleSection>?)await GymRulesDataProvider.GetRuleSectionsAsync();
        RulesSection = Sections?.FirstOrDefault();
        if (RulesSection != null)
        {
            SectionName = RulesSection.Name;
            Rules = (List<GymRule>?)await GymRulesDataProvider.GetRulesBySectionIdAsync(RulesSection.Id);
        }
    }

    private async void EditRulesSection_Click(RuleSection section)
    {
        RulesSectionVM = section.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("SectionModel", RulesSectionVM);
        parameters.Add("IsEdit", true);
        var dialog = DialogService.Show<CreateEditRulesSectionDialog>("CreateEditRulesSectionDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            //Sections = (List<RuleSection>?)await GymRulesDataProvider.GetRuleSectionsAsync();
            //RulesSection = await GymRulesDataProvider.GetRuleSectionAsync(section.Id);
            //Rules = (List<GymRule>?)await GymRulesDataProvider.GetRulesBySectionIdAsync(RulesSection!.Id);
            StateHasChanged();
        }
    }
    private async void CreateRulesSection_Click()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("SectionModel", null);
        parameters.Add("IsEdit", false);
        var dialog = DialogService.Show<CreateEditRulesSectionDialog>("CreateEditRulesSectionDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Sections = (List<RuleSection>?)await GymRulesDataProvider.GetRuleSectionsAsync();
            StateHasChanged();
        }
    }

    private async void EditRule_Click(GymRule rule)
    {
        RuleVM = rule.ConvertToViewModel();

        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("RuleModel", RuleVM);
        parameters.Add("IsEdit", true);
        parameters.Add("RulesSection", null);
        var dialog = DialogService.Show<CreateEditGymRuleDialog>("CreateEditGymRuleDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Rules = (List<GymRule>?)await GymRulesDataProvider.GetRulesBySectionIdAsync(RulesSection!.Id);
            StateHasChanged();
        }
    }

    private async void CreateRule_Click()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        var parameters = new DialogParameters();
        parameters.Add("RuleModel", null);
        parameters.Add("IsEdit", false);
        parameters.Add("RulesSection", RulesSection);
        var dialog = DialogService.Show<CreateEditGymRuleDialog>("CreateEditGymRuleDialog", parameters, options);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            Rules = (List<GymRule>?)await GymRulesDataProvider.GetRulesBySectionIdAsync(RulesSection.Id);
            StateHasChanged();
        }
    }

    private async Task HandleSectionChange()
    {
        RulesSection = Sections?.FirstOrDefault(s => s.Name == SectionName);
        Rules = (List<GymRule>?)await GymRulesDataProvider.GetRulesBySectionIdAsync(RulesSection!.Id);
        StateHasChanged();
    }

    private void GoToPreview_Click(GymRule rule)
    {
        //var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
        //var parameters = new DialogParameters
        //{
        //    { "GymRule", rule }
        //};
        //DialogService.Show<GymRuleViewItemDialog>("ViewGymRuleDialog", parameters, options);
    }

    private void HandleResetError()
    {
        ErrorMessage = null;
        StateHasChanged();
    }
}