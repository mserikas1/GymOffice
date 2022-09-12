namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IGroupTrainingRepository
{
    Task<Guid> AddTrainingAsync(GroupTraining groupTraining);
    Task<GroupTraining> DeleteAsync(Guid id);
    Task<IEnumerable<GroupTraining>?> GetAllAsync();
    Task<GroupTraining?> GetByIdAsync(Guid id);
    Task<IEnumerable<GroupTraining>?> GetTrainingsByCoachAsync(Guid coachId);
    Task<IEnumerable<GroupTraining>?> GetTrainingsByDateAsync(DateOnly date);
    Task<IEnumerable<GroupTraining>?> GetTrainingsByDateIntervalAsync(DateOnly startDate, DateOnly endDate);
    Task<IEnumerable<GroupTraining>?> GetTrainingsByNameAsync(string name);
    Task<IEnumerable<GroupTraining>?> GetTrainingsByTimeIntervalAsync(TimeOnly startTime, TimeOnly endTime);
}
