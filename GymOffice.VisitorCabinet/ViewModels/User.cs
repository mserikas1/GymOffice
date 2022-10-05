using Microsoft.AspNetCore.Identity;

namespace GymOffice.VisitorCabinet.ViewModels;

public class User : IdentityUser
{
    public string? RefreshToken { get; set; }
}