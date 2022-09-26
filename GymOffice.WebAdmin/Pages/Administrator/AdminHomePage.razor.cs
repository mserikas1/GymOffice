namespace GymOffice.WebAdmin.Pages.Administrator;
public partial class AdminHomePage : ComponentBase
{
    public string CoachesCardClasses { get; set; } = "ma-15 d-flex align-between light-green lighten-4 green-text text-darken-4";
    public string CoachesCardName { get; set; } = "Coaches";
    public int CoachesTotalCount { get; set; }
    public int CoachesInGymCount { get; set; }
    public string ReceptionistsCardClasses { get; set; } = "ma-15 d-flex align-between light-blue lighten-4 indigo-text text-darken-4";
    public string ReceptionistsCardName { get; set; } = "Receptionists";
    public int ReceptionistsTotalCount { get; set; }
    public int ReceptionistsInGymCount { get; set; }
    public string VisitorsCardClasses { get; set; } = "ma-15 d-flex align-between amber lighten-4 deep-orange-text text-darken-4";
    public string VisitorsCardName { get; set; } = "Visitors";
    public int VisitorsTotalCount { get; set; }
    public int VisitorsInGymCount { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public IEmployeeDataProvider EmployeeDataProvider { get; set; } = null!;
    [Inject]
    public ICoachDataProvider CoachDataProvider { get; set; } = null!;
    [Inject]
    public IVisitorDataProvider VisitorDataProvider { get; set; } = null!;


    protected override async Task OnInitializedAsync()
    {
        var receptionists = await EmployeeDataProvider.GetReceptionistsAsync();
        if (receptionists != null)
        {
            ReceptionistsTotalCount = receptionists.Count;
            ReceptionistsInGymCount = receptionists.Where(r => r.IsAtWork == true).Count();
        }
        var coaches = await CoachDataProvider.GetAllCoachesAsync();
        if (coaches != null)
        {
            CoachesTotalCount = coaches.Count;
            CoachesInGymCount = coaches.Where(c => c.IsAtWork == true).Count();
        }
        var visitors = await VisitorDataProvider.GetAllVisitorsAsync();
        if (visitors != null)
        {
            VisitorsTotalCount = visitors.Count;
            VisitorsInGymCount = visitors.Where(v => v.IsInGym == true).Count();
        }
    }

    private void RedirectToCoachesPage()
    {
        NavigationManager.NavigateTo("/admin/coaches");
    }

    private void RedirectToReceptionistsPage()
    {
        NavigationManager.NavigateTo("/admin/receptionists");
    }

    private void RedirectToVisitorsPage()
    {
        NavigationManager.NavigateTo("/admin/visitors");
    }
}