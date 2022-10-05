using System.ComponentModel.DataAnnotations;

namespace GymOffice.VisitorCabinet.ViewModels;

public class RefreshRequest
{
    [Required]
    public string AccessToken { get; set; }
    [Required]
    public string RefreshToken { get; set; }
}