namespace GymOffice.WebAdmin.Data.Contracts;
public interface IIdentityRepository
{
    Task<IdentityUser?> GetUserByEmailAsync(string email);
    Task<IdentityUser?> GetUserByIdAsync(Guid id);
    Task AddCoachAsync(CoachVM coachVM);
    Task UpdateCoachAsync(Coach coach);
    Task AddReceptionistAsync(ReceptionistVM receptionistVM);
    Task UpdateReceptionistAsync(Receptionist receptionist);
}
