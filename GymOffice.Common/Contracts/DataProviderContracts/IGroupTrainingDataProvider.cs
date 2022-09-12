namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IGroupTrainingDataProvider
{
    Task<GroupTraining?> GetTrainingByIdAsync(Guid id);
    Task<IEnumerable<GroupTraining>?> GetAllTrainingsAsync();
    Task<IEnumerable<GroupTraining>?> GetTrainingsByNameAsync(string name);
    Task<IEnumerable<GroupTraining>?> GetTrainingsByCoachAsync(Guid coachId);
    Task<IEnumerable<GroupTraining>?> GetTrainingsByDateAsync(DateOnly date);
    Task<IEnumerable<GroupTraining>?> GetTrainingsByTimeIntervalAsync(TimeOnly startTime, TimeOnly endTime);
    Task<IEnumerable<GroupTraining>?> GetTrainingsByDateIntervalAsync(DateOnly startDate, DateOnly endDate);
}
