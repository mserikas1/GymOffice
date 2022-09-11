namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IPersonalTrainingRepository
{
    Task<Training?> GetByIdAsync(Guid id);
    Task<IEnumerable<Training>?> GetAllAsync();
    Task<IEnumerable<Training>?> GetTrainingsByCustomerAsync(Guid customerId);
    Task<IEnumerable<Training>?> GetTrainingsByCoachAsync(Guid coachId);
    Task<Guid> AddTrainingAsync(Training training);
    Task<Training?> DeleteTrainingAsync(Guid id);
    Task<Training?> UpdateTrainingAsync(Training training);
    Task<IEnumerable<Training>?> GetTrainingsByDateAsync(DateOnly date);
    Task<IEnumerable<Training>?> GetTrainingsByTimeIntervalAsync(TimeOnly startTime, TimeOnly endTime);
    Task<IEnumerable<Training>?> GetTrainingsByDateIntervalAsync(DateOnly startDate, DateOnly endDate);
}
