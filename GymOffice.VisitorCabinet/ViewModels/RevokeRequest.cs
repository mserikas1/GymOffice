using System.ComponentModel.DataAnnotations;

namespace GymOffice.VisitorCabinet.ViewModels;

public class RevokeRequest
{
    [Required]
    public string RefreshToken { get; set; }
}