namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IPersonalTrainingDataProvider
{
    Task<Training?> GetTrainingByIdAsync(Guid id);
    Task<IEnumerable<Training>?> GetAllTrainingsAsync();
    Task<IEnumerable<Training>?> GetTrainingsByCustomerAsync(Guid customerId);
    Task<IEnumerable<Training>?> GetTrainingsByCoachAsync(Guid coachId);
    Task<IEnumerable<Training>?> GetTrainingsByDateAsync(DateOnly date);
    Task<IEnumerable<Training>?> GetTrainingsByDateIntervalAsync(DateOnly startDate, DateOnly endDate);
    Task<IEnumerable<Training>?> GetTrainingsByTimeIntervalAsync(TimeOnly startTime, TimeOnly endTime);
}
