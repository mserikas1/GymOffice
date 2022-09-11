namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IGroupTrainingRepository
{
    Task<IEnumerable<Training>?> GetAllAsync();
    Task<Training?> GetByIdAsync(Guid id);
    Task<IEnumerable<Training>?> GetTrainingsByCoachAsync(Guid coachId);
    Task<IEnumerable<Training>?> GetTrainingsByDateAsync(DateOnly date);
    Task<IEnumerable<Training>?> GetTrainingsByDateIntervalAsync(DateOnly startDate, DateOnly endDate);
    Task<IEnumerable<Training>?> GetTrainingsByNameAsync(string name);
    Task<IEnumerable<Training>?> GetTrainingsByTimeIntervalAsync(TimeOnly startTime, TimeOnly endTime);
}
