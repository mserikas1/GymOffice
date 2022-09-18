﻿using System.ComponentModel;

namespace GymOffice.WebAdmin.ViewModels;
public class CreatedReceptionistVM
{    
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
    [StringLength(10)]
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
    [RegularExpression(@"^[А-ГҐДЕЄЖЗИІЇЙК-Я]{2}\d{6}", ErrorMessage = "Passport must be like \"AB123456\"")]
    public string PassportNumber { get; set; } = String.Empty;
    
    public string? PhotoUrl { get; set; }
}