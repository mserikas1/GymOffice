namespace GymOffice.WebAdmin.ViewModels;
public class ReceptionistVM
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
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone Number must be a string with length of 10 digits")]
    public string PhoneNumber { get; set; } = String.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;

    [Required]
    [PasswordPropertyText]
    [StringLength(30, ErrorMessage = "Password must be at least 8 characters long", MinimumLength = 8)]
    public string Password { get; set; } = String.Empty;

    [Required]
    [PasswordPropertyText]
    [Display(Name = "Password Confirm")]
    [Compare(nameof(Password), ErrorMessage = "'Confirm Password' and 'Password' must be the same")]
    public string PasswordConfirm { get; set; } = String.Empty;

    [Required]
    [Display(Name = "Passport")]
    [StringLength(8)]
    [RegularExpression(@"^[А-ГҐДЕЄЖЗИІЇЙК-Я]{2}\d{6}", ErrorMessage = "Passport must be like \"AЯ123456\"")]
    public string PassportNumber { get; set; } = String.Empty;

    public Admin CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public Admin ModifiedBy { get; set; } = null!;

    public DateTime ModifiedAt { get; set; }

    public bool IsAtWork { get; set; }

    public bool IsActive { get; set; }

    public string? PhotoUrl { get; set; }

    public ICollection<JobSchedule> JobScheduleItems { get; set; } = new List<JobSchedule>();
}
