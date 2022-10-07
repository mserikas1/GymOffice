using System.ComponentModel.DataAnnotations;

namespace GymOffice.VisitorCabinet.ViewModels
{
    public class RegisterVisitorVM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
