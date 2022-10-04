namespace GymOffice.CustomerApi.ViewModels;

public class AuthResponse
{
    public string FisrtName { get; set; }
    public string LastName { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}