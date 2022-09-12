namespace GymOffice.Common.Contracts.DataProviderContracts;
public interface IPersonalTrainingDataProvider
{
    Task<PersonalTraining?> GetTrainingByIdAsync(Guid id);
    Task<IEnumerable<PersonalTraining>?> GetAllTrainingsAsync();
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByCustomerAsync(Guid customerId);
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByCoachAsync(Guid coachId);
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByDateAsync(DateOnly date);
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByDateIntervalAsync(DateOnly startDate, DateOnly endDate);
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByTimeIntervalAsync(TimeOnly startTime, TimeOnly endTime);
}
