namespace GymOffice.CustomerApi.ViewModels
{
    public class GroupedAbonnementTypeVM
    {
        public string Name { get; set; } = null!;
        public string StartVisitTime { get; set; } = null!;
        public string EndVisitTime { get; set; } = null!;
        public string? Description { get; set; }
        public decimal MinPrice { get; set; }
    }
}
