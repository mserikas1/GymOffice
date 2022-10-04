using Microsoft.AspNetCore.Identity;

namespace GymOffice.CustomerApi.ViewModels;

public class User : IdentityUser
{
    public string? RefreshToken { get; set; }
}