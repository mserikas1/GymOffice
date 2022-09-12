namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ICoachRepository
{
    Task<IEnumerable<Coach>?> GetAllCoachesAsync();
    Task<IEnumerable<Coach>?> GetActiveCoachesAsync();
    Task<Coach?> GetByIdAsync(Guid id);
    Task<Guid> AddCoachAsync(Coach coach);
    Task<Coach> UpdateCoachAsync(Coach coach);
    Task<Coach> DeleteCoachAsync(Guid id);
    Task<IEnumerable<Coach>?> SearchCoachesAsync(CoachSearchOptions options);
    Task AddGroutTrainingToCouchAsync(GroupTraining groupTraining, Guid coachId);
    Task DeleteGroupTrainingFromCoachAsync(Guid trainingId, Guid coachId);
}
