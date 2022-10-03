namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ICoachRepository
{
    Task<ICollection<Coach>?> GetAllCoachesAsync();
    Task<ICollection<Coach>?> GetActiveCoachesAsync();
    Task<ICollection<Coach>?> GetActiveCoachesNotAtWorkAsync();
    Task<ICollection<Coach>?> GetCoachesAtWorkAsync();
    Task<ICollection<Coach>?> GetCoachesNotAtWorkAsync();
    Task<Coach?> GetCoachByIdAsync(Guid id);
    Task AddCoachAsync(Coach coach);
    Task UpdateCoachAsync(Coach coach);
    Task<ICollection<Coach>?> SearchCoachesAsync(CoachSearchOptions options);
    ICollection<Coach>? GetActiveCoaches();
}
