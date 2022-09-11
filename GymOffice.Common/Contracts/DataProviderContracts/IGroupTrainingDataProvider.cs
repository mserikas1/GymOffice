namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IGroupTrainingDataProvider
{
    Task<Training?> GetTrainingByIdAsync(Guid id);
    Task<IEnumerable<Training>?> GetAllTrainingsAsync();
    Task<IEnumerable<Training>?> GetTrainingsByNameAsync(string name);
    Task<IEnumerable<Training>?> GetTrainingsByCoachAsync(Guid coachId);
    Task<IEnumerable<Training>?> GetTrainingsByDateAsync(DateOnly date);
    Task<IEnumerable<Training>?> GetTrainingsByTimeIntervalAsync(TimeOnly startTime, TimeOnly endTime);
    Task<IEnumerable<Training>?> GetTrainingsByDateIntervalAsync(DateOnly startDate, DateOnly endDate);
}
