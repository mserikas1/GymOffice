namespace GymOffice.WebAdmin.ViewModels;
public class VisitorVM
{
    public Guid Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Name length must be between 2 and 20 characters")]
    public string FirstName { get; set; } = String.Empty;

    [Required]
    [Display(Name = "Last Name")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Name length must be between 2 and 20 characters")]
    public string LastName { get; set; } = String.Empty;

    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    [StringLength(13, MinimumLength = 12, ErrorMessage = "Phone Number must be a string with length of 12-13 digits")]
    public string PhoneNumber { get; set; } = String.Empty;
    
    [EmailAddress]
    public string Email { get; set; } = String.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsActive { get; set; }
    public bool IsInGym { get; set; }
    public string? PhotoUrl { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Guid VisitorCardId { get; set; }
    public VisitorCard VisitorCard { get; set; } = null!; // Barcode, CreatedBy and RegistrationDate fields of the Card are shown but not changed
}
