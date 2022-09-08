namespace GymOffice.Common.Contracts.RepositoryContracts;
public interface ITrainingRepository
{
    Task<IEnumerable<Training>?> GetAllTrainingAsync();
    Task<IEnumerable<Training>?> GetTrainingByCustomerAsync(Guid customerId);
    Task<IEnumerable<Training>?> GetTrainingByCoachAsync(Guid coachId);
    Task<Guid> AddTrainingAsync(Training training);
    Task<Training?> DeleteTrainingAsync(Guid id);
    Task<Training?> UpdateTrainingAsync(Training training);
}
