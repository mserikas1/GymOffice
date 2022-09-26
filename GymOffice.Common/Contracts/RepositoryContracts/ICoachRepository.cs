namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ICoachRepository
{
    Task<ICollection<Coach>?> GetAllCoachesAsync();
<<<<<<< HEAD
=======
    Task<ICollection<Coach>?> GetActiveCoachesAsync();
    Task<ICollection<Coach>?> GetActiveCoachesNotAtWorkAsync();
    Task<ICollection<Coach>?> GetCoachesAtWorkAsync();
    Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync();
    Task<Coach?> GetCoachByIdAsync(Guid id);
    Task<Guid> AddCoachAsync(Coach coach);
    Task UpdateCoachAsync(Coach coach);
>>>>>>> oleg-feature-receptionist-pages
}
