namespace GymOffice.WebAdmin.ViewModels;
public class CoachVM
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
    [StringLength(13, MinimumLength = 12, ErrorMessage = "Phone Number must be a 13-digit string, like \"+380XXXXXXXX\"")]
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

    public string? Education { get; set; }

    public string? Description { get; set; }

    public Admin CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public Admin ModifiedBy { get; set; } = null!;

    public DateTime ModifiedAt { get; set; }

    public bool IsAtWork { get; set; }

    public bool IsActive { get; set; }

    public string PhotoUrl { get; set; } = string.Empty;

    public ICollection<JobSchedule> JobScheduleItems { get; set; } = new List<JobSchedule>();

    public ICollection<PersonalTraining> PersonalTrainings { get; set; } = new List<PersonalTraining>();

    public ICollection<GroupTraining> GroupTrainings { get; set; } = new List<GroupTraining>();
}
