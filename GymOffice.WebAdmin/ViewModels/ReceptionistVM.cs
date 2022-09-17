namespace GymOffice.WebAdmin.ViewModels;
public class ReceptionistVM
{    
    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Name length must be between 2 and 20 characters")]
    public string FirstName { get; set; } = String.Empty;

    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Name length must be between 2 and 20 characters")]
    public string LastName { get; set; } = String.Empty;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = String.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;

    [Required]
    [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
    public string Password { get; set; } = String.Empty;

    [Required]
    [Compare(nameof(Password))]
    public string Password2 { get; set; } = String.Empty;

    [Required]
    public string PassportNumber { get; set; } = String.Empty;

    [Url]
    public string? PhotoUrl { get; set; }
}
