namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface IPersonalTrainingRepository
{
    Task<PersonalTraining?> GetByIdAsync(Guid id);
    Task<IEnumerable<PersonalTraining>?> GetAllAsync();
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByCustomerAsync(Guid customerId);
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByCoachAsync(Guid coachId);
    Task<Guid> AddTrainingAsync(PersonalTraining training);
    Task<PersonalTraining?> DeleteTrainingAsync(Guid id);
    Task<PersonalTraining?> UpdateTrainingAsync(PersonalTraining training);
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByDateAsync(DateOnly date);
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByTimeIntervalAsync(TimeOnly startTime, TimeOnly endTime);
    Task<IEnumerable<PersonalTraining>?> GetTrainingsByDateIntervalAsync(DateOnly startDate, DateOnly endDate);
}
