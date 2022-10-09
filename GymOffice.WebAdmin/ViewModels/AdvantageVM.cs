namespace GymOffice.WebAdmin.ViewModels
{
    public class AdvantageVM
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string PhotoUrl { get; set; } = string.Empty;
        public Admin CreatedBy { get; set; } = null!;
        public Admin ModifiedBy { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
