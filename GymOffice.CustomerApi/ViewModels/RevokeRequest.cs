using System.ComponentModel.DataAnnotations;

namespace GymOffice.CustomerApi.ViewModels;

public class RevokeRequest
{
    [Required]
    public string RefreshToken { get; set; }
}