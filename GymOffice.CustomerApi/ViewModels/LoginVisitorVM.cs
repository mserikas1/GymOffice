using Microsoft.Build.Framework;

namespace GymOffice.CustomerApi.ViewModels
{
    public class LoginVisitorVM
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
