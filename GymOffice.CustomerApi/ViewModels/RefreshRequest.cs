using System.ComponentModel.DataAnnotations;

namespace GymOffice.CustomerApi.ViewModels;

public class RefreshRequest
{
    [Required]
    public string AccessToken { get; set; }
    [Required]
    public string RefreshToken { get; set; }
}