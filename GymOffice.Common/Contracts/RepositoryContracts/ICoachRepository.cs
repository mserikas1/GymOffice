namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ICoachRepository
{
    Task<ICollection<Coach>?> GetAllCoachesAsync();
    Task<ICollection<Coach>?> GetActiveCoachesAsync();
    Task<ICollection<Coach>?> GetActiveCoachesNotAtWorkAsync();
    Task<ICollection<Coach>?> GetCoachesAtWorkAsync();
    Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync();
    Task<Coach?> GetCoachByIdAsync(Guid id);
    Task<Guid> AddCoachAsync(Coach coach);
    Task UpdateCoachAsync(Coach coach);
}
