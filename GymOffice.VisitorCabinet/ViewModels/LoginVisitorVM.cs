using System.ComponentModel.DataAnnotations;

namespace GymOffice.VisitorCabinet.ViewModels
{
    public class LoginVisitorVM
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
